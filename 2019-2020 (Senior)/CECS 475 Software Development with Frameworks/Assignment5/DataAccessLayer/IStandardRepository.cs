﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IStandardRepository : IRepository<Standard>
    {

    }

    public interface IStudentRepository : IRepository<Student>
    {

    }
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        public StudentRepository() : base(new SchoolDBEntities())
        {

        }
    }
}