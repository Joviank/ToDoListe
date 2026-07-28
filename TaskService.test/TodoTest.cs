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
    public void DeleteTask_ShouldRemoveTask()
    {
       
    }
}
