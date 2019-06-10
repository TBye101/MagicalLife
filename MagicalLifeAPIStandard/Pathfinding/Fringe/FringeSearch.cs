using MagicalLifeAPI.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Pathfinding.Fringe
{
    public class FringeSearch
    {
        private void GetParentNodes(DPoint start, DPoint goal)
        {
            //F must have .isEmpty()
            //F must be iterable from "left" to "right"
            //F must have .contains() or some way to do that
            //F must have .remove()
            //F must have .insert(n)
            //F must have .remove(n)

            List<DPoint> F = new List<DPoint>();
            HashSet<DPoint> C = new HashSet<DPoint>();
            //C[n] <- null for n != start
            //flimit <- h(start)
            float fmin;
            bool found = false;
            while (!found || F.Count > 0)
            {
                fmin = float.PositiveInfinity;
                //Iterate over nodes n which is a part of F from left to right
                    //(g, parent) = C[n]
                    //f = g + h(n)

                    //if (f > flimit)
                    //{
                        //fmin = min(f, fmin);
                        //continue;
                    //}

                    //if (n == goal)
                    //{
                        //found = true;
                        //break;
                    //}

                    //Iterate over s which is successors from n (AKA: successors(n)) from right to left
                        //gs = g + cost(n, s);
                        //if (C[s] != null)
                        //{
                            //(g', parent) = C[s]
                            //if (gs >= g')
                            //{
                            //continue;
                            //}
                        //}
                        //if (F.contains(s))
                        //{
                        //  F.remove(s);
                        //}
                        //F.insert s after n
                        //C[s] = (gs, n)
                    //F.remove(n);
                //flimit = fmin;
            //if (found)
            //{
                //return this.constructFromParentNodes(C);
            //}
            //else
            //{
                //return a null value or throw an exception.
            //}
            }

        }
    }
}
