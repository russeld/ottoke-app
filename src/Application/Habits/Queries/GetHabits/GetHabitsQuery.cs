using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;

namespace Application.Habits.Queries.GetHabits;

public record GetHabitsQuery(string ApplicationUserId) : IQuery<Result<List<Habit>>>;
