using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECharts.Entities
{	 	
	/// <summary>
	/// 直角坐标系内绘图网格
	/// </summary>
    public class Grid : Basic<Grid>
    {
        public string type { get; set; }

        public object x2 { get; set; }

        public object y2 { get; set; }
	 

        public object getX { get; set; }

        public object getXend { get; set; }

        public object getY { get; set; }

        public object getYend { get; set; }

        public object getWidth { get; set; }

        public object getHeight { get; set; }

        public object getArea { get; set; }



        public Grid X2(object x2) {
            this.x2 = x2;
            return this;
        }

        public Grid Y2(object y2)
        {
            this.y2 = y2;
            return this;
        }

		public bool? containLabel{
			get;
			set;
		}

		
		public Grid ContainLabel(bool containLabel)
		{
		    this.containLabel = containLabel;
			return null;
		}
		 
    }
}
