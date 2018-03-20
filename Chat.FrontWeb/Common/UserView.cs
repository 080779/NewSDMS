using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;
using SDMS.Service.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SDMS.Web.Common
{
    public class UserView
    {

        public RowView use = new RowView();
        public readonly UserDTO us = new UserDTO();
        private long _ViewID=9;
        private int _a=2;
        private int _b=3;
        private int _c=3;
        private int _isht;
        private int _isadmin;
        public IUserService userServer = new UserService();
        public ILevelService levelServer = new LevelService();
        public string AddTable(long Id,int znode)
        {
            _ViewID = Id;
            //nodedt(this._ViewID, this._b);
            //dt = LevelBLL.GetListByCache("UserView");
            int a = this._a;
            int b = znode;
            int cs = userServer.NodeNun(_ViewID);
            use.AddRange(userServer.GetLayerModelList((cs - 1), (cs + znode)));
            string Tabele = "";
            Tabele += top(a, b);
            ArrayList alist = new ArrayList();
            ArrayList blist = new ArrayList();
            alist.Add("0," + _ViewID);
            int type;
            for (int i = 0; i < b; i++)
            {
                int x = Convert.ToInt32(Math.Pow(a, i));
                int y = Convert.ToInt32(Math.Pow(a, b)) / (a * x);
                if (i == 0)
                {
                    type = 0;
                }
                else if (i == b - 1)
                {
                    type = 2;
                }
                else
                {
                    type = 1;
                }
                Tabele += addTr(type, x, y, a, alist, out blist);
                alist = blist;
            }
            Tabele += Ends();
            return Tabele;
        }
        /// <summary>
        /// 输出TR
        /// </summary>
        /// <param name="Wtype"></param>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="alist"></param>
        /// <param name="blist"></param>
        /// <returns></returns>
        private string addTr(int Wtype, int id, int x, int a, ArrayList alist, out ArrayList blist)
        {
            ArrayList clist = new ArrayList();
            List<UserDTO> li = new List<UserDTO>();
            for (int i = 0; i < id; i++)
            {
                string[] fx = alist[i].ToString().Split(',');
                UserDTO fd = userServer.GetModel(int.Parse(fx[1]));
                if (fd != null)
                {
                    fd.User005 = x.ToString();
                    li.Add(fd);
                    for (int j = 1; j < a + 1; j++)
                    {
                        int Myid;
                        if (use.Exist(int.Parse(fx[1]), j, out Myid))
                        {
                            clist.Add("0," + Myid.ToString());
                        }
                        else
                        {
                            if (fd.IsOpend >= 2)
                                clist.Add("0,-1," + fx[1] + "," + j);
                            else if (fd.IsOpend == 0 || fd.IsOpend == 1)
                                clist.Add("2,-1," + fx[1] + "," + j);
                        }
                    }
                }
                else
                {
                    if (fx[0] == "0")//父节点已开通
                    {
                        if (userServer.GetLocationModel(int.Parse(fx[2])) == null)
                        {
                            if (int.Parse(fx[3]) == 2)
                            {
                                fd = new UserDTO();
                                fd.User005 = x.ToString();
                                fd.UserCode = "[空位]";
                                li.Add(fd);
                            }
                            else
                            {
                                fd = new UserDTO();
                                fd.User005 = x.ToString();
                                fd.UserCode = "[空位]";
                                fd.ParentID = int.Parse(fx[2]);
                                fd.Location = int.Parse(fx[3]);
                                li.Add(fd);
                            }
                        }
                        else
                        {
                            fd = new UserDTO();
                            fd.User005 = x.ToString();
                            fd.UserCode = "[空位]";
                            fd.ParentID = int.Parse(fx[2]);
                            fd.Location = int.Parse(fx[3]);
                            li.Add(fd);
                        }
                    }
                    else
                    {
                        if (fx[0] == "2")//父节点未开通
                        {
                            if (int.Parse(fx[3]) == 2)
                            {
                                fd = new UserDTO();
                                fd.User005 = x.ToString();
                                fd.UserCode = "[空位]";
                                li.Add(fd);
                            }
                            else
                            {
                                fd = new UserDTO();
                                fd.User005 = x.ToString();
                                fd.UserCode = "[空位]";
                                fd.ParentID = int.Parse(fx[2]);
                                fd.Location = int.Parse(fx[3]);
                                li.Add(fd);
                                //fd = new lgk.Model.tb_user();
                                //fd.User005 = x.ToString();
                                //fd.UserCode = "[空位]";
                                //li.Add(fd);
                            }
                        }
                        else
                        {
                            fd = new UserDTO();
                            fd.User005 = x.ToString();
                            fd.UserCode = "[空位]";
                            li.Add(fd);
                        }
                    }
                    for (int j = 0; j < a; j++)
                    {
                        clist.Add("1,-1");
                    }
                }
            }
            blist = clist;
            return Aid(li, Wtype, a);
        }
        private string TTable(UserDTO sd)
        {
            StringBuilder sbContent = new StringBuilder();
            List<string> nodeli = new List<string>();
            if (sd.UserCode == "[注册]")
            {
                string urlname = "";
                if (_isadmin == 1)
                    urlname = "Registers";//后台
                else
                    urlname = "Register";//前台
                sbContent.Append("<table  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"map05\">");
                sbContent.Append("<tr>");
                sbContent.Append("<td width=\"102\" height=\"26\"   colspan=\"2\"  class=\"cBlack\">");
                sbContent.Append("<a href=\"../../" + urlname + ".aspx?state=" + sd.ParentID + "," + sd.Location + "," + this._isht + "," + this._ViewID + "\">注册</a>");
                //sbContent.Append("空位");
                sbContent.Append("</td></tr>");
                sbContent.Append("</table>");
            }
            else if (sd.UserCode == "[空位]")
            {
                sbContent.Append("<table  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"map06\"><tr><td width=\"102\" height=\"26\"   colspan=\"2\" class=\"cBlack\">空位</td></tr></table>");
                
            }
            else
            {
                string map = "";
                string kaitong = "";
                string strlevelName = "";
                if (sd.LevelID > 0)
                {
                    strlevelName =levelServer.GetLevelName(sd.LevelID).LevelName;
                }
                if (sd.IsOpend == 0 || sd.IsOpend == 1)
                {
                    kaitong = "<span style='color:red;'>[未激活]</span>";
                    map = "image0";
                }
                else
                {
                    kaitong = "[已激活]";
                    if (int.Parse(sd.LevelID.ToString()) > 0)
                    {
                        map = "image2";// 
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 2)
                    {
                        map = "image2"; // 金卡代理 
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 3)
                    {
                        map = "image3";// 钻卡代理
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 4)
                    {
                        map = "image4"; // 
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 5)
                    {
                        map = "image6";//
                    }
                }
               
                    sbContent.Append(" <table height=\"100px\"  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"" + map + "\">" +
                        "<tr height=\"5px\"><td align=\"center\"  colspan=\"3\" class=\"th\"><b><a style=\" color:White;\" href=\"/Admin/Team/MemberTree?tt=" + sd.ID + "\">" + sd.UserCode + "(" + strlevelName + ")" + "</a></b></td></tr>" +
                        "<tr  align=\"center\" height=\"5px\"><td align=\"center\"  colspan=\"3\" class=\"th\">" + sd.TrueName + "</td></tr>" +
                        "<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftScore).ToString() + "</td><td>总</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightScore).ToString() + "</td></tr>" +
                        //"<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftBalance).ToString() + "</td><td>余</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightBalance).ToString() + "</td></tr>" +
                        "<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftNewScore).ToString() + "</td><td>新</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightNewScore).ToString() + "</td></tr>" +
                        "</table>");
                
            }
            return sbContent.ToString();
        }
        /// <summary>
        /// 输出一行内的所有TD
        /// </summary>
        /// <param name="fd"></param>
        /// <returns></returns>
        private string Aid(List<UserDTO> fd, int Wtype, int a)
        {
            StringBuilder sbContent = new StringBuilder();
            sbContent.Append("<tr  align=\"center\" >");
            foreach (UserDTO ad in fd)
            {
                sbContent.Append("<td colspan=\"" + ad.User005 + "\" align=\"center\" >");
                sbContent.Append(TTable(ad));
                sbContent.Append("</td>");
            }

            sbContent.Append("</tr>");



            if (Wtype == 2)
            {
                return sbContent.ToString();
            }

            foreach (UserDTO ad in fd)
            {
                switch (a)
                {
                    case 1:

                        sbContent.Append("<td  align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\"><img alt=\"父节点\" width=\"10\" height=\"30\" src=\"/images/t_tree_mind.gif\" /></td>");
                        break;
                    case 2:

                        sbContent.Append("<td  align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\"><img alt=\"height=30\" src=\"/images/t_tree_bottom_l.gif\" /><img height=\"30\" src=\"/images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((78 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"父节点\" width=\"10\" height=\"30\" src=\"/images/t_tree_mid.gif\" /><img height=\"30\"");
                        sbContent.Append("src=\"/images/t_tree_line.gif\" width=\"" + (((78 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"/images/t_tree_bottom_r.gif\" /></td>");
                        break;
                    case 3:
                        sbContent.Append("<td  align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\"><img alt=\"height=30\" src=\"/images/t_tree_bottom_l.gif\" /><img height=\"30\" src=\"/images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((78 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"父节点\" height=\"30\" src=\"/images/t_tree_mind.gif\" /><img height=\"30\"");
                        sbContent.Append("src=\"/images/t_tree_line.gif\" width=\"" + (((78 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"/images/t_tree_bottom_r.gif\" /></td>");
                        break;
                    case 4:
                        sbContent.Append("<td align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\">");
                        sbContent.Append("<img alt=\"height=30\" src=\"/images/t_tree_bottom_l.gif\" /><img height=\"30\" src=\"/images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((55 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"/images/t_tree_bottom_l.gif\" /><img height=\"30\"");
                        sbContent.Append("src=\"/images/t_tree_line.gif\" width=\"" + (((27 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"父节点\" height=\"30\" src=\"/images/t_tree_mid.gif\"");
                        sbContent.Append("width=\"10\" /><img height=\"30\" src=\"/images/t_tree_line.gif\" width=\"" + (((27 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\"");
                        sbContent.Append("src=\"/images/t_tree_bottom_r.gif\" /><img height=\"30\" src=\"/images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((55 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"/images/t_tree_bottom_r.gif\" /></td>");
                        break;
                    case 5:
                        sbContent.Append("<td align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\">");
                        sbContent.Append("<img alt=\"height=30\" src=\"/images/t_tree_bottom_l.gif\" /><img height=\"30\" src=\"/images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((43 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"/images/t_tree_bottom_l.gif\" /><img height=\"30\"");
                        sbContent.Append("src=\"/images/t_tree_line.gif\" width=\"" + (((43 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"父节点\" height=\"30\" src=\"/images/t_tree_mind.gif\"");
                        sbContent.Append("width=\"10\" /><img height=\"30\" src=\"/images/t_tree_line.gif\" width=\"" + (((43 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\"");
                        sbContent.Append("src=\"/images/t_tree_bottom_r.gif\" /><img height=\"30\" src=\"/images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((43 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"/images/t_tree_bottom_r.gif\" /></td>");
                        break;
                    default:
                        break;
                }

            }
            sbContent.Append("</tr>");
            return sbContent.ToString();
        }
        /// <summary>
        /// 输出顶部
        /// </summary>
        /// <returns></returns>
        private string top(int a, int b)
        {
            int Wid = 0;
            switch (a)
            {
                case 2:
                    Wid = Convert.ToInt32(Math.Pow(a, b));//
                    break;
                case 3:
                    Wid = Convert.ToInt32(Math.Pow(a, b)) / 2;
                    break;
                case 4:
                    Wid = Convert.ToInt32(Math.Pow(a, b)) / 4;
                    break;
                default:
                    break;
            }
            StringBuilder sbContent = new StringBuilder();
            sbContent.Append("<table align=\"center\" id=\"treeTable\" style=\"width:" + Wid * 78 + "px\">");
            return sbContent.ToString();
        }
        /// <summary>
        /// 输出底部
        /// </summary>
        /// <returns></returns>
        private string Ends()
        {
            StringBuilder sbContent = new StringBuilder();
            sbContent.Append("</table>");
            return sbContent.ToString();
        }
    }
}