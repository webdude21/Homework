namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;

    using StudentSystem.Data.Contracts;
    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    public class StudentsSystemData : IStudentSystemData
    {
        private readonly IStudentSystemDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public StudentsSystemData()
            : this(new StudentSystemDbContext())
        {
        }

        public StudentsSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public GenericRepository<Course> Courses
        {
            get
            {
                return (GenericRepository<Course>)this.GetRepository<Course>();
            }
        }

        public GenericRepository<Student> Students
        {
            get
            {
                return (GenericRepository<Student>)this.GetRepository<Student>();
            }
        } 

        public GenericRepository<Teacher> Teachers
        {
            get
            {
                return (GenericRepository<Teacher>)this.GetRepository<Teacher>();
            }
        }

        public GenericRepository<Homework> Homeworks
        {
            get
            {
                return (GenericRepository<Homework>)this.GetRepository<Homework>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (this.repositories.ContainsKey(typeOfModel))
            {
                return (IGenericRepository<T>)this.repositories[typeOfModel];
            }
            
            var type = typeof(GenericRepository<T>);

            this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}