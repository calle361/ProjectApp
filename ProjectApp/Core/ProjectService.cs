using System.Data;
using ProjectApp.Core.Interfaces;
using ProjectApp.Persistence;

namespace ProjectApp.Core;

public class ProjectService : IProjectService
{
    private readonly IProjectPersistence _projectPersistence;

    public ProjectService(IProjectPersistence projectPersistence)
    {
        _projectPersistence = projectPersistence;
    }
    
    public List<Project> GetAllByUserName(string userName)
    {
        List<Project> projects = _projectPersistence.GetAllByUserName(userName);
        return projects;
    }

    public Project GetById(int id, string userName)
    {
        Project project = _projectPersistence.GetById(id, userName);
        if(project == null) throw new DataException("project not found");
        return project;
    }

    public void Add(string userName, string title)
    {
        if (userName == null) throw new DataException("username missing");
        if (title==null||title.Length>128) throw new DataException("title");

        Project project = new Project(title, userName);
        _projectPersistence.Save(project);
    }
}