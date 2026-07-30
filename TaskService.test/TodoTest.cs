namespace TaskService.test;

public class TodoTest
{
    [Fact]
    public void AddTask_ShouldAddTaskToDatabase()
    {
        // Arrange
        var task = new TaskService();

        //Act
        task.AddTask("Laundry");

        //Assert
        Assert.Single(task.GetTasks());
    }

    [Fact]
    public void AddTask_ShouldStoreCorrectTitle()
    {
        // Arrange
        var taskClass = new TaskService();

        // Act
        taskClass.AddTask("To learn TDD");

        // Assert
        var task = taskClass.GetTasks().First();
        Assert.Equal("To learn TDD", task.Title);
    }

    [Fact]
    public void CompleteTask_ShouldMarkTaskAsCompleted()
    {
        // Given
        var taskClass = new TaskService();
        var task = taskClass.AddTask("Wake up");
    
        // When
        taskClass.CompleteTask(task.Id);
    
        // Then
        Assert.True(taskClass.GetTasks().First().IsCompleted);
    }

    [Fact]
    public void CompleteTask_ShouldThrow_WhenTaskDoesNotExist()
    {
        // Arrange 
        var taskClass = new TaskService();

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => taskClass.CompleteTask(500));
    }

    [Fact]
    public void DeleteTask_ShouldRemoveTask()
    {
        // Arrange
        var taskClass = new TaskService();
        var task = taskClass.AddTask("Do stuff");

        // Act
        taskClass.DeleteTask(task.Id);

        // Assert
        Assert.Empty(taskClass.GetTasks());
    }

    [Fact]
    public async Task HTTPHealth_ReturnsOK()
    {
        var client = new HttpClient();

        var response = await client.GetAsync("http://localhost:5125/health");

        Assert.True(response.IsSuccessStatusCode);
    }
}
