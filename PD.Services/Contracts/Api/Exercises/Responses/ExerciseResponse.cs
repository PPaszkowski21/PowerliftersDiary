﻿using PD.Services.Contracts.Api.ExercisesDetails.Response;
using PD.Services.Contracts.Api.ExercisesEquipments.Responses;
using PD.Services.Services;
using PowerlifterDiary.Models;

namespace PD.Services.Contracts.Api.Exercises.Responses
{
    public class ExerciseResponse
    {
        public ExerciseResponse(Exercise exercise)
        {
            Id = exercise.Id;
            Name = exercise.Name;
            Description = exercise.Description;
            BodyPart = exercise.BodyPart;
            if(exercise.ExerciseEquipment!=null)
            {
                ExerciseService exerciseService = new ExerciseService();
                ExerciseEquipment = exerciseService.GetExerciseEquipment(exercise.ExerciseEquipment.Id);
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BodyPart { get; set; }
        public ExerciseEquipmentResponse ExerciseEquipment { get; set; }
    }
}
