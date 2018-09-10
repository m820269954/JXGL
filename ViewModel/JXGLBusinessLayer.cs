using jxgl.Data_Access_Layer;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;

namespace jxgl.ViewModel
{
    public class JXGLBusinessLayer:DbContext
    {
        //（学生）查看目前选课的信息
        public List<CSViewModel> GetCS(string Sno)
        {
            JXGLDBContext context = new JXGLDBContext();
            var list = from cs1 in context.Courses
                       join cs2 in context.CSs
                       on cs1.Cno equals cs2.Cno
                       join cs3 in context.TCs
                       on cs2.Cno equals cs3.Cno
                       join cs4 in context.Teachers
                       on cs3.Tno equals cs4.Tno
                       join cs5 in context.Students
                       on cs2.Sno equals cs5.Sno
                       where cs2.Sno == Sno
                       select new CSViewModel
                       {
                           Cno = cs1.Cno,
                           Cname = cs1.Cname,
                           Tno = cs4.Tno,
                           Tname = cs4.Tname,
                           Ctrem = cs1.Ctrem,
                           Ctime = cs1.Ctime,
                           Ccredit = cs1.Ccredit,
                           Score = cs2.Score
                       };
            List<CSViewModel> css = new List<CSViewModel>();
            foreach(CSViewModel cs in list)
            {
                css.Add(cs);
            }
            return css;
        }
        //学生选课
        public List<CSViewModel> GetSC(string Sno)
        {
            JXGLDBContext context = new JXGLDBContext();
            var list = from cs1 in context.Courses
                            join cs2 in context.TCs
                            on cs1.Cno equals cs2.Cno
                            join cs3 in context.Teachers
                            on cs2.Tno equals cs3.Tno
                       where !( from f in context.CSs
                                where f.Sno == Sno
                                select f.Cno
                                ).Contains(cs1.Cno)
                       select new CSViewModel
                       {
                           Cno = cs1.Cno,
                           Cname = cs1.Cname,
                           Tno = cs2.Tno,
                           Tname = cs3.Tname,
                           Ctrem = cs1.Ctrem,
                           Ctime = cs1.Ctime,
                           Ccredit = cs1.Ccredit,
                           Checked = false
                       };
            List<CSViewModel> css = new List<CSViewModel>();
            foreach (CSViewModel cs in list)
            {
                css.Add(cs);
            }
            return css;
        }
        //（教师）查看教师的学生信息
        public List<StudentViewModel>  GetStudents(string Tname)
        {
            JXGLDBContext context = new JXGLDBContext();
            var list = (from s1 in context.Students
                           join s2 in context.CSs
                           on s1.Sno equals s2.Sno
                           join s3 in context.TCs
                           on s2.Cno equals s3.Cno
                           join s4 in context.Courses
                           on s3.Cno equals s4.Cno
                           where s3.Tno == Tname
                           select new StudentViewModel()
                           {
                               Sno = s1.Sno,
                               Sname = s1.Sname,
                               Sacad = s1.Sacad,
                               Sscore = s2.Score,
                               Ssex = s1.Ssex,
                               Cno=s3.Tno,
                               Cname=s4.Cname
                           }).ToList();
            List<StudentViewModel> models = new List<StudentViewModel>();
            foreach (StudentViewModel student in list)
            {
                models.Add(student);
            }
            return models;
            
        }
        public string ChangePwd(string newpwd,string UserName,string UserGroup)
        {
            if (UserGroup == "Student")
            {
                JXGLDBContext context = new JXGLDBContext();
                var S = context.Students.Find(UserName);
                S.Spwd = newpwd;
                context.SaveChanges();
                return "success";
            }
            else if (UserGroup == "Teacher")
            {
                JXGLDBContext context = new JXGLDBContext();
                var S = context.Teachers.Find(UserName);
                S.Tpwd = newpwd;
                context.SaveChanges();
                return "success";
            }
            else
            {
                JXGLDBContext context = new JXGLDBContext();
                var S = context.Admins.Find(UserName);
                S.Apwd = newpwd;
                context.SaveChanges();
                return "success";

            }
        }
        //还未实现查看选课人数
        public List<jxgl.ViewModel.TCViewModel> GetTc(string Tno)
        {
            JXGLDBContext context = new JXGLDBContext();
            List<jxgl.ViewModel.TCViewModel> list =( from t1 in context.TCs
                       join t2 in context.Courses
                       on t1.Cno equals t2.Cno
                       where t1.Tno == Tno
                       select new TCViewModel()
                       {
                           Cno = t1.Cno,
                           Cname = t2.Cname,
                           Time = t1.Time,
                           Day = t1.Day,
                           Location = t1.Location,
                           RoomNum = t1.RoomNum,
                           StarTime = t1.StarTime,
                           EndTime = t1.EndTime
                       }).ToList();
            return list;
        }
        public string IsAuth(string ume,string pwd)
        {
            JXGLDBContext context = new JXGLDBContext();
            if (ume.Length == 11)//学生
            {
                var user = from u in context.Students
                           where u.Sno == ume && u.Spwd == pwd
                           select u;
                if (user.Count()!=0)
                {

                    FormsAuthentication.SetAuthCookie(ume, false);
                    return "Student";
                }
            }
            else if (ume.Length == 7)//教师{
            {
                var user = from u in context.Teachers
                           where u.Tno == ume && u.Tpwd == pwd
                           select u;
                if (user.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(ume, false);
                    return "Teacher";
                }

            }
            else//管理员
            {
                var user = from u in context.Admins
                           where u.Aname == ume && u.Apwd == pwd
                           select u;
                if (user.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(ume, false);
                    return "Admin";
                }
                
            }
            return "error";
        }
    }
}