using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.stencyl.io.mbs.shape;

namespace haxe_mbs_translate.src.stencyl.models.scene
{
    public class Wireframe
    {
        public PointF position;
        public PointF[] points;

        public Wireframe(PointF position, PointF[] points)
        {
            this.position = position;
            this.points = points;
        }

        public static Wireframe FromMbs(MbsWireframe mbs)
        {
            MbsList<MbsPoint> mbsPoints = mbs.getPoints();
            PointF[] convertedPoints = new PointF[mbsPoints.length()].Select(i =>Convert(mbsPoints.getNextObject())).ToArray();

            return new Wireframe(Convert(mbs.getPosition()), convertedPoints);
        }

        public static PointF Convert(MbsPoint p)
        {
            return new PointF(p.getX(), p.getY());
        }

        public override string ToString()
        {
            return ToString(false);
        }
        public string ToString(bool expandPoints)
        {
            string output = $"Wireframe at ({position.X},{position.Y}): {points.Length} points";
            if(expandPoints) output += "\n\t" + String.Join("\n\t", points.Select(i => $"({i.X},{i.Y})"));
            return output;
        }

        /// <param name="mbs">A pre-allocated mbs which is capable of writing.</param>
        public MbsWireframe WriteMbs(MbsWireframe mbs)
        {
            MbsPoint pos = mbs.getPosition(); pos.setX(position.X); pos.setY(position.Y);

            MbsList<MbsPoint> list = mbs.createPoints(points.Length);

            foreach(PointF point in points)
            {
                MbsPoint p = list.getNextObject();
                p.setX(point.X);
                p.setY(point.Y);
            }

            return mbs;
        }
    }
}
