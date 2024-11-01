using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;

namespace DecentralizedErp.APIs;

public interface IProjectsService
{
    /// <summary>
    /// Create one Project
    /// </summary>
    public Task<Project> CreateProject(ProjectCreateInput project);

    /// <summary>
    /// Delete one Project
    /// </summary>
    public Task DeleteProject(ProjectWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Projects
    /// </summary>
    public Task<List<Project>> Projects(ProjectFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Project records
    /// </summary>
    public Task<MetadataDto> ProjectsMeta(ProjectFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Project
    /// </summary>
    public Task<Project> Project(ProjectWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Project
    /// </summary>
    public Task UpdateProject(ProjectWhereUniqueInput uniqueId, ProjectUpdateInput updateDto);
}
