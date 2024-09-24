﻿using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Buffers.Text;
using System.Security.Cryptography.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace MVCProject.PL.Notes
{
    public class Notes
    {

        //1  Step DAl =>Model
        //2  Class Configuration
        //3  Add DBSet
        //4  Apply Configuration
        //5  Add Migration
        //6  BLL
        //7  Repository for each Model 5 Action That will call database
        //8  Each Repository Have interface
        //9  Create Class Employee
        //10 Create Generic Interface if need 
        //11 Create Generic Class for department and employee
        //12 Create Controller Employee 
        //13 Create view for each action in controller
        //14 services for this Model

        #region MVC03
        // if you install package in DAl and you want to Pl see that you must build the project
        //First we must divide it to services 
        //AFTER THAT we will code the Data Access layer
        //Data file contain migration + Configuration + dbContext 
        #endregion

        #region MVC04

        #region Interface For Repository

        // in MVC we work with 3 layer architecture 
        // in Business logic layer we work with repository design pattern or unit of work
        // repository design pattern have to type with and without generic
        // Generic used to reduce repetition
        // interfaces in onion architecture is in core(domain) layer
        // interfaces in 3 tier architecture is in business logic layer
        // in repository folder each model will create repository for him (5 action)
        // we make interface(code contract = action inside repository) for each repository 
        //من خلال الانترفيس بنحدد شكل الريبوزتري بحيث لو اكتر من داتا بيز 
        //و عندي اكتر من ريبو لنفس الموديل  يبقي ليهم نفس الميثود 
        // implement against interface not against concrete class
        #endregion

        #region Dependency Injection
        // DepartmentRepository علشان اكريت اوبجيكت من ال 
        // CLR فا ال  AppDbContext معتمد علي حقن اوبجيكت من ال
        // AppDbContext هيروح الستارت اب يشوف انت عامل ريجيستر للسيرفيس بتاعت ال
        //  فا هيروح يكريت اوبجيكت منه عن طريق البرامتر ليس كونستراكتور 
        // DbContext الي بيتشين علي الكونستراكتور بتاع البيز 
        // البرامتر ليس بتاع البيز بيعمل تشين علي كونستراكتور بياخد برامتر من نوع
        // onconfigring الي من جواه بينفز ال   DbContextOptions
        // الداتا بيز استرينج onconfigring الي موجود في optionsBuilder بنبعت عن طريق ال 

        // بدل ما نعمل تشين علي الكونستراكتور بتاع البيز 
        // هنعمل اتشين علي البرامتاريزد علي طول 
        #endregion


        #region Migration
        // we need apply migration after doing model and other
        // we install package tool in PL that i will run migration on it (project have app setting)
        // make PL is the start up project 
        // we add migration folder on DAL 
        //Add-Migration "initialCreate" -context AppDbContext          -output Data/Migration 
        //               name of mig    -DbContext that will connect  - folder that will add mig

        #endregion

        #region Presentation Layer (MVC Project)
        //Assembly reference from another solution
        //project reference from same solution
        //launchBrowser": true after deploy open browser
        //windowsAuthentication true no one will access app unless user in server

        #endregion

        #endregion

        #region MVC05

        #region Create view 

        //first you will create for action (index) view 
        //second you have option to use layout default or browse 
        //he will scaffolding to create HTML view
        //after creating view the first thing you must to do is detect model that will model despite what we will use it (get - add - delete0
        //binding what type of data will view use 
        //type of model is the same type of what action that will call view return 

        #endregion

        #endregion

        #region MVC06

        #region Generic Repository
        // if you see the code in interface department repository and interface employee repository they are the same 
        // the only deferent is the model  (domain model) so we didn't need to repeat code 
        // we will make interface generic repository of T 
        // we need interface for generic repository before generic repository
        // open for extension closed for modification 

        // if you look to implementation of method in department repository and employee repository
        // you will find that they are the same we don't need to repeat code so
        // so we will make Generic repository class have this method and each of them inherit from that
        #endregion

        #region ClentSideValidation
        //Client side validation before submission he will show the validation
        //so he didn't send request to server that we don't need
        // we will do it in view that have form
        //first we need jQuery validation library
        //we need to connect this library with view
        //we add it at the end of the view not beginning
        //note if you add this library in create view this library will not be in the end of the view
        //because the default layout contain more code after the form
        //and library of jQury validation depend on jQury so it must became after it
        //so i want when he render create view he create all things dispute this link 
        //i want to render it in another place using Section to add links in it
        //Section have name and we will render it in RenderSectionAsync in layout
        //@IgnoreSection if you want to ignore specific section
        // in layout one randerBody one or more renderSection
        #endregion

        #region PartialView
        // if we look at create view and edit view we found they are the same
        // if we look at Details view and delete view we found they are the same
        // we need to add repeated code in one place =>Partial view 
        //partial view contain repeated code
        //there is three button in index employee and index department identical
        //we will add it partial view and render it in each file you want
        //we will add this partial view in shared folder because it contain code of two model
        //the name of partial view is any thingPartial
        #endregion

        #region ImportantComperions(Razer Pages)
        //1.View : HTML Page that action return(response)
        //2.Partial View : part of view that repeat in more than one view added in partial view and render it in any view
        //3._Layout View : more than one view have the same structure same(head - footer - navbar )
        //4._ViewImports : contain all imports that i want to didn't repeat in each view
        //5._ViewStart : any code on it added on the start of each view
        //6.Section : if i have part of code i didn't wont to render it in render body
        //view render in render body and section render in render section in any place
        #endregion

        #region ViewData Vs ViewBag
        //Binding : Data Send From Action to View 
        //action take data of model from =>  1.Form(input with the same name) 2.Segment 3.Query String
        //Action Have HTTP Get Always data send  form action to View 
        //Action Have HTTP Post Always data send form View to action(Model)
        //if i want to send extra information to view (extra binding) in addition to the model i already send
        //i can't send two model using helper method
        //each view have dictionary i access it using view data or view bag
        //Binding through view's Dictionary : transfer Data from Action to View
        //ViewData Vs ViewBag property that allow to access dictionary of view
        //use this dictionary to send any data
        //you set information that you want to send in action
        //dictionary key(must be string) + value pair you access this information using key in view
        //ViewData Vs ViewBag inherited form controller
        //data send from action to view in one way (ذهاب بلا عوده)
        //ViewData Vs ViewBag use the same dictionary
        #endregion

        #region ViewData Vs ViewBag

        //1.ViewData
        //is a Dictionary Object(Introduced in ASP.Net Framework 3.5 )
        //it helps Us to Transfer Data From Controller[Action] To Its View Or From View To View[Layout]
        //2.ViewBag
        //is a Dynamic property(Introduced in ASP.Net Framework 4.0 Based On Dynamic Keyword)
        //it helps Us to Transfer Data From Controller[Action] To Its View Or From View To View[Layout]


        #endregion

        #region TempData
        //TempData : Send data from action(request) to action (request) 
        //TempData : has his Owen Dictionary
        #endregion

        #endregion


        #region MVC07

        #region EmployeeDepartmentRelation
        // we work code first so we will do relation by code (navigation property)
        // we want to access employee from department and department from employee (Two Dimension relation)
        // FK name is the name of entity + PK (By Convention )
        #endregion

        #region SelectTagHelpers
        // i want when user create employee choose the department
        // we need input for department (create - edit )
        #endregion

        #region AddSingletonAddScopedAddTransient
        //AddSingleton : object lifetime = Application lifetime
        //service we need his lifetime is singleton : cashing service( Get Response - Cash Response ) one object
        //Cashing : first get data form database then if you need this data again he search local first
        //service we need his lifetime is singleton : Logging exception
        //object we create remains while user open application (per user)
        //we have design pattern called singleton prevent multiple object creation from class
        //AddScoped    : object lifetime = Request lifetime
        //service we need his lifetime is Scoped : Repository
        //AddTransient : object lifetime = Operation lifetime
        //service we need his lifetime is Transient : Mapping( Map from model to viewModel(class that work with view) or opposite)
        //object for each operation (create - delete - update ) object per operation

        //we need to collect all services and detect lifetime in extension method or static method and call it in ConfigureServices 
        #endregion

        #region Search

        #endregion

        #region Mapping
        //Model : Class Represent Table in Database
        //ViewModel : Class That Rendered In View 
        //Action Index take data from database as Model and send it to view
        //That's Wrong Because May be Model Have some property we don't need to show in View
        //And my be we Have some data in View we don't need in Model to Store it in Database
        //So we need to convert from Model to ViewModel Before Take Index[HTTP GET]
        //Or from ViewModel to Model Before Take Create [HTTP POST]
        //all View will operate with View model not model
        #endregion

        #endregion

        #region MVC08
        //   42     +     20    +    20     +     9    +     20   +    35  =   145    
        #endregion
    }
}
