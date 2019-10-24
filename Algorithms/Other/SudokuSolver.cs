using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Algorithms
{
    /// <summary>
    /// Ported from http://norvig.com/sudo.py by Richard Birkby, June 2007.
    /// See http://norvig.com/sudoku.html
    /// Also, https://bugzilla.mozilla.org/attachment.cgi?id=266577 - Javascript1.8 version
    /// </summary>
    public static class LinqSudokuSolver
    {
        // Throughout this program we have:
        public static string rows = "ABCDEFGHI";
        public static string cols = "123456789";
        public static string digits = "123456789";
        public static string[] squares = cross(rows, cols);
        /// <summary>
        /// 行，列，宫的集合汇总
        /// </summary>
        public static List<string[]> unitlist;
        /// <summary>
        /// 单元格及其关联的行、列、宫集合
        /// </summary>
        public static Dictionary<string, IGrouping<string, string[]>> units;
        /// <summary>
        /// 单元格及其关联的行、列、宫包含的单元格
        /// </summary>
        public static Dictionary<string, IEnumerable<string>> peers;
             
        /// <summary>
        /// 求笛卡尔积
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static string[] cross(string A, string B)
        {
            return (from a in A from b in B select "" + a + b).ToArray();
        }

        static LinqSudokuSolver()
        {
            /*
             * unitlist = ([cross(rows, c) for c in cols] +
             *           [cross(r, cols) for r in rows] +
             *           [cross(rs, cs) for rs in ('ABC','DEF','GHI') for cs in ('123','456','789')])
             */
            unitlist = ((from c in cols select cross(rows, c.ToString()))
                .Concat(from r in rows select cross(r.ToString(), cols))
                .Concat(from rs in (new[] { "ABC", "DEF", "GHI" }) from cs in (new[] { "123", "456", "789" }) select cross(rs, cs))).ToList();

            /*
             * units = dict((s, [u for u in unitlist if s in u]) 
             *   for s in squares)
             */
            units = (from s in squares from u in unitlist where u.Contains(s) group u by s into g select g).ToDictionary(g => g.Key);

            /*
             * peers = dict((s, set(s2 for u in units[s] for s2 in u if s2 != s))
             *   for s in squares)
             */
            peers = (from s in squares from u in units[s] from s2 in u where s2 != s group s2 by s into g select g).ToDictionary(g => g.Key, g => g.Distinct());

        }

        public static string[][] zip(string[] A, string[] B)
        {
            var n = Math.Min(A.Length, B.Length);
            string[][] sd = new string[n][];
            for (var i = 0; i < n; i++)
            {
                sd[i] = new string[] { A[i].ToString(), B[i].ToString() };
            }
            return sd;
        }

        /// <summary>Given a string of 81 digits (or . or 0 or -), return a dict of {cell:values}</summary>
        public static Dictionary<string, string> parse_grid(string grid)
        {
            //var grid2 = from c in grid where "0.-123456789".Contains(c) select c;
            var values = squares.ToDictionary(s => s, s => digits); //To start, every square can be any digit

            foreach (var sd in zip(squares, (from s in grid select s.ToString()).ToArray()))
            {
                var s = sd[0];
                var d = sd[1];

                if (digits.Contains(d) && assign(values, s, d) == null)
                {
                    return null;
                }
            }
            return values;
        }

        /// <summary>Using depth-first search and propagation, try all possible values.</summary>
        public static Dictionary<string, string> search(Dictionary<string, string> values)
        {
            if (values == null)
            {
                return null; // Failed earlier
            }
            if (all(from s in squares select values[s].Length == 1 ? "" : null))
            {
                return values; // Solved!
            }

            // Chose the unfilled square s with the fewest possibilities
            var s2 = (from s in squares where values[s].Length > 1 orderby values[s].Length ascending select s).First();

            return some(from d in values[s2]
                        select search(assign(new Dictionary<string, string>(values), s2, d.ToString())));
        }

        /// <summary>Eliminate all the other values (except d) from values[s] and propagate.</summary>
        public static Dictionary<string, string> assign(Dictionary<string, string> values, string s, string d)
        {
            if (all(
                    from d2 in values[s]
                    where d2.ToString() != d
                    select eliminate(values, s, d2.ToString())
                    )
                )
            {
                return values;
            }
            return null;
        }

        // Eliminate d from values[s]; propagate when values or places <= 2.
        /// <summary>Eliminate d from values[s]; propagate when values or places <= 2.</summary>
        public static Dictionary<string, string> eliminate(Dictionary<string, string> values, string s, string d)
        {
            if (!values[s].Contains(d))
            {
                return values;
            }
            values[s] = values[s].Replace(d, "");
            if (values[s].Length == 0)
            {
                return null; //Contradiction: removed last value
            }
            else if (values[s].Length == 1)
            {
                //If there is only one value (d2) left in square, remove it from peers
                var d2 = values[s];
                if (!all(from s2 in peers[s] select eliminate(values, s2, d2)))
                {
                    return null;
                }
            }

            //Now check the places where d appears in the units of s
            foreach (var u in units[s])
            {
                var dplaces = from s2 in u where values[s2].Contains(d) select s2;
                if (dplaces.Count() == 0)
                {
                    return null;
                }
                else if (dplaces.Count() == 1)
                {
                    // d can only be in one place in unit; assign it there
                    if (assign(values, dplaces.First(), d) == null)
                    {
                        return null;
                    }
                }
            }
            return values;
        }

        public static bool all<T>(IEnumerable<T> seq)
        {
            foreach (var e in seq)
            {
                if (e == null) return false;
            }
            return true;
        }

        public static T some<T>(IEnumerable<T> seq)
        {
            foreach (var e in seq)
            {
                if (e != null) return e;
            }
            return default(T);
        }

        public static string Center(this string s, int width)
        {
            var n = width - s.Length;
            if (n <= 0) return s;
            var half = n / 2;

            if (n % 2 > 0 && width % 2 > 0) half++;

            return new string(' ', half) + s + new String(' ', n - half);
        }

        /// <summary>Used for debugging.</summary>
        public static Dictionary<string, string> print_board(Dictionary<string, string> values)
        {
            if (values == null) return null;

            var width = 1 + (from s in squares select values[s].Length).Max();
            var line = "\n" + String.Join("+", Enumerable.Repeat(new String('-', width * 3), 3).ToArray());

            foreach (var r in rows)
            {
                Console.WriteLine(String.Join("",
                    (from c in cols
                     select values["" + r + c].Center(width) + ("36".Contains(c) ? "|" : "")).ToArray())
                        + ("CF".Contains(r) ? line : ""));
            }

            Console.WriteLine();
            return values;
        }

        public static string grid1 = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";

        public static void Test()
        {
            var easy = "..3.2.6..9..3.5..1..18.64....81.29..7.......8..67.82....26.95..8..2.3..9..5.1.3..";
            var chuji = "....6............52.4.3....9.6...2.....5........8.......9.42....7.....58........1";
            print_board(parse_grid(chuji));
            print_board(search(parse_grid(chuji)));

            Console.WriteLine("Press enter to finish");
            Console.ReadLine();
        }

        public static bool solved(Dictionary<string, string> values)
        {
            var unitsolved = new Func<IEnumerable<string>, bool>(unit => !new HashSet<string>(unit.Select((s) => values[s])).Intersect(new HashSet<string>(digits.Select(x => x.ToString()))).Any());
            return values != null && all(unitlist.Select((unit) => unitsolved(unit)));
        }

    }
}
