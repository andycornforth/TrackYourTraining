/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Muscle] ([MuscleName], [OtherNames]) VALUES ('Quadriceps', 'Quads'), ('Hamstrings', 'Hams'), ('Gluteus maximus', 'Glutes, Bum'), ('Calves', 'Calf'), ('Pectorals', 'Chest, Pecs'), ('Deltoids','Shoulders, Delts'),('Latissimus dorsi', 'Lats, Back, Upper-back'),('Lower-back', NULL),('Trapezius','Traps, Neck'), ('Abdominals', 'Core'),('Obliques', NULL), ('Biceps', 'Bis'), ('Triceps', 'Tris'), ('Forearm',NULL);

INSERT INTO [dbo].[Movement] ([MovementName], [PrimaryMuscleId], [SecondaryMuscles], [WeightTypeId], [DifficultyLevelId], [Description] ) 
VALUES ('High Bar Squat', 1, 'Glutes, Hamstrings, Core', 0, 2, 'The high bar squat is a compound, full body exercise that trains primarily the muscles of the thighs, hips and buttocks, quadriceps (vastus lateralis, vastus medialis, vastus intermedius and rectus femoris), hamstrings, as well as strengthening the bones, ligaments and insertion of the tendons throughout the lower body.'),
('Barbell Bench Press', 5, 'Triceps, Shoulders, Core', 0, 1, 'The bench press is an upper body strength training exercise that consists of pressing a weight upwards from a supine position. The exercise works the pectoralis major as well as supporting chest, arm, and shoulder muscles like the anterior deltoids, serratus anterior, coracobrachialis, scapulae fixers, trapezii, and the triceps.'),
('Deadlift', 1, 'Glutes, Hamstrings, Lower-back, Core', 0, 2, 'The deadlift is a weight training exercise in which a loaded barbell is lifted off the ground to the hips, then lowered back to the ground. It is one of the three powerlifting exercises, along with the squat and bench press.');
