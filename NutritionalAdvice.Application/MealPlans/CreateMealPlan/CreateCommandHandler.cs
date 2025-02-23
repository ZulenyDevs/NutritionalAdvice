using MediatR;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.MealPlans.CreateMealPlan
{
    public class CreateCommandHandler : IRequestHandler<CreateMealPlanCommand, Guid>
    {
        private readonly IMealPlanFactory _mealPlanFactory;
        private readonly IMealPlanRepository _mealPlanRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(IMealPlanFactory mealPlanFactory,
            IMealPlanRepository mealPlanRepository,
            IUnitOfWork unitOfWork)
        {
            _mealPlanFactory = mealPlanFactory;
            _mealPlanRepository = mealPlanRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateMealPlanCommand request, CancellationToken cancellationToken)
        {
            var mealPlan = _mealPlanFactory.Create(request.name, request.description, request.goal, request.dailyCalories, request.dailyProtein, request.dailyCarbohydrates, request.dailyFats, request.nutritionistId, request.patientId);

            await _mealPlanRepository.AddAsync(mealPlan);

            await _unitOfWork.CommitAsync(cancellationToken);

            return mealPlan.Id;
        }
    }
}
