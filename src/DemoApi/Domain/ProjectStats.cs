namespace DemoApi.Domain;

/// <summary>Сводка по задачам проекта</summary>
/// <param name="ProjectId">Идентификатор проекта</param>
/// <param name="Total">Всего задач</param>
/// <param name="Todo">В статусе Todo</param>
/// <param name="InProgress">В статусе InProgress</param>
/// <param name="Done">В статусе Done</param>
/// <param name="Overdue">Просрочено: срок прошёл, статус не Done</param>
public sealed record ProjectStats(int ProjectId, int Total, int Todo, int InProgress, int Done, int Overdue);
