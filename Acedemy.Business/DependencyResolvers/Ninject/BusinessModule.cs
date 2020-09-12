using Acedemy.Business.Abstract;
using Acedemy.Business.Concrete;
using Acedemy.DataAccess;
using Acedemy.DataAccess.Abstract;
using Acedemy.DataAccess.Concrete;
using FrameworkCore.Abstract;
using FrameworkCore.Concrete;
using FrameworkCore.Utilities.Mappings;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseDal>().To<CourseDal>().InSingletonScope();
            Bind<ICourseService>().To<CourseManager>().InSingletonScope(); ;
            Bind<IAutoMapperBase>().To<AutoMapperHelper>().InSingletonScope();

            Bind<IStudentDal>().To<StudentDal>().InSingletonScope();
            Bind<IStudentService>().To<StudentManager>().InSingletonScope();

            Bind<IAttendanceDal>().To<AttendanceDal>().InSingletonScope();
            Bind<IAttendanceService>().To<AttendanceManager>().InSingletonScope();
            Bind<IAttendanceDetailDal>().To<AttendanceDetailDal>().InSingletonScope();
            Bind<IUserDal>().To<UserDal>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IInstructorService>().To<InstructorManager>().InSingletonScope();
            Bind<IInstructorDal>().To<InstructorDal>().InSingletonScope();
            Bind<IValidateService>().To<ValidateManager>().InSingletonScope();


            //Bind<DbContext>().To<AcedemyContext>();

        }
    }
}
