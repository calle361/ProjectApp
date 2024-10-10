﻿using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;

using Task = ProjectApp.Core.Task;

namespace ProjectApp.Persistence;

public class MySqlProjectPersistence : IProjectPersistence
{
    private readonly ProjectDbContext _dbContext;
    private readonly IMapper _mapper;

    public MySqlProjectPersistence(ProjectDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public List<Project> GetAllByUserName(string userName)
    {
        var projectDbs = _dbContext.ProjectDbs
            .Where(p => p.UserName == userName)
            .ToList(); 

        List<Project> result = new List<Project>();
        foreach(ProjectDb pdb in projectDbs)
        {
            Project project = _mapper.Map<Project>(pdb);
            result.Add(project);
        }

        return result;
    }

    public Project GetById(int id, string userName)
    {
        ProjectDb? projectdb = _dbContext.ProjectDbs
            .Where(p => p.Id == id && p.UserName.Equals(userName))
            .Include(p => p.TaskDbs)
            .FirstOrDefault(); // null if not found!
        
        if (projectdb == null) throw new DataException("project not found");

        Project project = _mapper.Map<Project>(projectdb);
        foreach (TaskDb taskDb in projectdb.TaskDbs)
        {
            Task task = _mapper.Map<Task>(taskDb);
            project.AddTask(task);
        }

        return project;
    }

    public void Save(Project project)
    {
        ProjectDb pdb= _mapper.Map<ProjectDb>(project);
        _dbContext.ProjectDbs.Add(pdb);
        _dbContext.SaveChanges();
    }
}