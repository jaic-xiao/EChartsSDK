﻿using ECharts.Entities.series;
using ECharts.Entities.series.data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECharts;
using ECharts.Entities;

namespace EChartsWeb.Util
{
    public class ChartsUtil
    {

        public static string ConvertChartsData(ChartData chartData)
        {
            var str = "app.title = '" + chartData.title + "';\r\n";


            if (!string.IsNullOrEmpty(chartData.ajax))
            {
                str += "$.get('" + chartData.ajax + "',function(data){\r\n";
            }
            if (chartData.data != null)
            {
                foreach (var data in chartData.data)
                {
                    str += "var " + data.Key + " =" + JsonTools.ObjectToJson2(data.Value) + ";\r\n ";
                }
            }

            if (chartData.fun != null)
            {
                foreach (var fun in chartData.fun)
                {
                    str += "var " + fun.Key + " =" + JsonTools.ObjectToJson2(fun.Value) + ";\r\n ";
                }
            }

            if (chartData.fundata != null)
            {
                foreach (var fd in chartData.fundata)
                {
                    str += "var " + fd.Key + " =" + JsonTools.ObjectToJson2(fd.Value) + ";\r\n ";
                }
            }

            if (chartData.beforeRaw != null)
            {
                foreach (var raw in chartData.beforeRaw)
                {
                    str += JsonTools.ObjectToJson2(raw) + ";\r\n ";
                }
            }
            if (chartData.option != null)
            {
                if (chartData.IsSetOption)
                {
                    str += "myChart.setOption( option = " + JsonTools.ObjectToJson2(chartData.option) + ");\r\n";
                }
                else
                {
                    str += "option =" + JsonTools.ObjectToJson2(chartData.option) + ";\r\n ";
                }
            }
          

            

            if (chartData.raw != null)
            {
                foreach (var raw in chartData.raw)
                {
                    str += JsonTools.ObjectToJson2(raw) + ";\r\n ";
                }
            }
            
            if (!string.IsNullOrEmpty(chartData.ajax))
            {
               str += "});";
            }

            return str;
        }

        public static IList<string> Weeks()
        {
            IList<string> weeks = new List<string>(){
              "周一",
              "周二",
              "周三",
              "周四",
              "周五",
              "周六",
              "周日",
            };
            return weeks;
        }

        public static IList<string> Months()
        {
            IList<string> months = new List<string>(){
              "一月","二月","三月", "四月","五月","六月",
              "七月","八月","九月","十月","十一月","十二月"
            };
            return months;
        }

        public static IList<string> Ads()
        {
            IList<string> ads = new List<string>()
            {
            "邮件营销","联盟广告","视频广告","直接访问","搜索引擎"
            };
            return ads;
        }

        public static IList<string> Ses()
        {
            IList<string> ses = new List<string>()
            {
            "百度","谷歌","必应"
            };
            return ses;
        }
       
        public static IList<string> Pops()
        {
            IList<string> ses = new List<string>()
            {
                "巴西", "印尼", "美国", "印度", "中国", "世界人口(万)"
            };
            return ses;
        }

        public static IList<double> DDatas(int len, int min, int max)
        {
            IList<double> datas = new List<double>();
            Random r = new Random();
            for (int i = 0; i < len; i++)
            {
                datas.Add(r.NextDouble() * r.Next(min, max));
            }
            return datas;
        }

        public static IList<int> Exps(int len, int exp)
        {
            IList<int> exps = new List<int>();
            for (int i = 0; i < len; i++)
            {

                exps.Add((int)Math.Pow(exp, i));
            }
            return exps;
        }

        public static IList<int> Sequences(int start,int end)
        {
            IList<int> datas = new List<int>();

            for (int i = start; i <= end; i++)
            {
                datas.Add(i);
            }
            return datas;
        }

        public static IList<int> Datas(int len, int min, int max)
        {
            IList<int> datas = new List<int>();
            Random r = new Random();
            for (int i = 0; i < len; i++)
            {
                datas.Add(r.Next(min, max));
            }
            return datas;
        }

        public static int[,] TowDatas(int row, int col,int min,int max)
        {
            int[,] datas = new int[row,col];
            Random r = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    datas[i,j] = r.Next(min, max);
                }
            }
            return datas;
        }

        public static IList<DateTime> TimeSteps(DateTime startTime, DateTime endTime, TimeSpan step)
        {
            IList<DateTime> times = new List<DateTime>();
            for (DateTime st = startTime; st < endTime; st = st.Add(step))
            {
                times.Add(st);
            }
            return times;
        }

        public static IList<DateTime> TimeSteps(DateTime startTime, DateTime endTime, TimeSpan minStep, TimeSpan maxStep)
        {
            IList<DateTime> times = new List<DateTime>();
            Random r = new Random();
            for (DateTime st = startTime; st < endTime;)
            {
                int step = r.Next(minStep.Hours, maxStep.Hours);
                st = st.AddHours(step);
                times.Add(st);
            }
            return times;
        }

        public static IList<double> Rains()
        {
            IList<double> rains = ChartsData.Rains;
            return rains;
        }

        public static IList<double> Flows()
        {
            IList<double> flows = ChartsData.Flows;
            return flows;
        }

        private static int GetProb(IList<double> prob)
        {
            int result = 0;
            int n = (int)(prob.Sum() * 1000);
            Random r = new Random();
            double x = (float)r.Next(0, n) / 1000;
            for (int i = 0; i < prob.Count(); i++)
            {
                double pre = prob.Take(i).Sum();
                double next = prob.Take(i + 1).Sum();
                if (x >= pre && x < next)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static IList<int> Steps(int len, int start, int step) {
            IList<int> datas = new List<int>();
            for (int i = 0; i < len; i++)
            {
                datas.Add(start + i * step);
            }
            return datas;
        }

        public static IList<Bar> EconDatas(int year,IList<string> provider)
        {
            IList<Bar> bars = new List<Bar>();
            foreach (var data in provider)
            {
                var bar = new Bar();
                bar.data = new JRaw(string.Format("{0}[{1}]", data, year));
                bars.Add(bar);
            }
            return bars;
        }

        public static IList<Scatter> EconDatas2(int year, IList<string> provider)
        {
            IList<Scatter> scatters = new List<Scatter>();
            foreach (var data in provider)
            {
                var scatter = new Scatter();
                scatter.data = new JRaw(string.Format("{0}[{1}]", data, year));
                scatters.Add(scatter);
            }
            return scatters;
        }

        public static IList<string> GenString(string name, int count)
        {
            IList<string> names = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                names.Add(name + i);
            }
            return names;
        }

        public static IList<Pie> GetBrowsersData(int count)
        {
            var idx = 1;
            IList<Pie> pies = new List<Pie>();
            for (int i = 0; i < count; i++)
            {
                var pie = new Pie("浏览器（数据纯属虚构）");
                var pd1 = new PieData<int>(idx * 128 + 80, "Chrome");
                var pd2 = new PieData<int>(idx * 64 + 160, "Firefox");
                var pd3 = new PieData<int>(idx * 32 + 320, "Safari");
                var pd4 = new PieData<int>(idx * 16 + 640, "IE9+");
                var pd5 = new PieData<int>(idx++ * 8 + 1280, "IE8-");
                pie.Data(pd1, pd2, pd3, pd4, pd5);
                pies.Add(pie);
            }           
            return pies;
        }
    }
}