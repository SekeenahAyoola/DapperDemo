using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace TMADapper.Context
{
    public class DbContext
    {
        public string connectionStrings = "Server=localhost;User=root;Database=TutoringApp;Password=isthaxx";

        private void Execution(string querry)
        {
            using(var connection = new MySqlConnection(connectionStrings))
            {
                connection.Open();
                connection.Execute(querry);
            }
        }
        public void CreateSchema()
        {
            var querry = "create schema if not exists TutoringApp";
            var connectionString = "Server=localhost;User=root;Password=isthaxx";
            using(var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(querry);
            }
        }

        public void CreateUserTable()
        {
            var querry = @"create table if not exists user(Id int auto_increment, IsDeleted bool, DateCreated varchar(50) , DateModified varchar(50),FirstName varchar(225) not null,LastName varchar(225) not null,Email varchar(225) unique not null, Password varchar(225) not null ,Gender enum('Male', 'Female'),PhoneNumber varchar(11),Age int not null,Role varchar(225),primary key(Id))";
            Execution(querry);
        }

        public void CreateTuteeTable()
        {
            var querry = @"create table if not exists Tutee(Id int auto_increment, UserId int, TuteeLevel enum ('Jss1','Jss2','Jss3', 'Ss1','Ss2','Ss3') not null,primary key(Id), foreign key(UserId) references User(Id))";
            Execution(querry);
        }

        public void CreateTutorTable()
        {
            var querry = @"create table if not exists Tutor(Id int auto_increment,UserId int,Qualification varchar (100), primary key(Id), foreign key(UserId) references User(Id))";
            Execution(querry);
        }
        public void CreateAdminTable()
        {
            var querry = @"create table if not exists Admin(Id int auto_increment,UserId int, primary key(Id), foreign key(UserId) references User(Id))";
            Execution(querry);
        }

        public void CreateCommentTable()
        {
            var querry = @"create table if not exists Comment(Id int auto_increment, IsDeleted bool,DateCreated varchar(50), DateModified varchar(50),TutorId int ,primary key(Id), foreign Key (TuteeId) references Tutee (Id))";
            Execution(querry);
        }
        public void CreateRatingTable()
        {
            var querry = @"create table if not exists Rating(Id int auto_increment, IsDeleted bool,DateCreated varchar(50), DateModified varchar(50),TutorId int ,primary key(Id), foreign Key (TutorId) references Tutor (Id))";
            Execution(querry);
        }

        public void CreatePlayerTable()
        {
            var querry = @"create table if not exists player(Id int auto_increment,UserName varchar(50),TuteeId int, IsDeleted bool,DateCreated varchar(50), DateModified varchar(50), primary key(Id), foreign key(TuteeId) references Tutee(Id))";
            Execution(querry);
        }
        public void CreateSuperAdminTable()
        {
            var querry = @"create table if not exists SuperAdmin(Id int auto_increment,UserId int, primary key(Id), foreign key(UserId) references User(Id) )";
            Execution(querry);
        }
        
    }
}