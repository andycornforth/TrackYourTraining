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

INSERT INTO [dbo].[WeightType] ([Name]) VALUES ('Barbell'),('Dumbbell'), ('Kettlebell'),('Bodyweight'),('Machine'), ('Static stretch'),('Dynamic stretch');

INSERT INTO [dbo].[DifficultyLevel] ([Level]) VALUES ('Beginner'),('Intermediate'),('Advanced'),('Expert');

INSERT INTO [dbo].[WeightPercentage] ([WeightPercentageName]) VALUES ('Weight'), ('Percentage of 1 Rep Max'), ('No Specified Weight');

INSERT INTO [dbo].[Muscle] ([MuscleName], [OtherNames]) VALUES ('Quadriceps', 'Quads'), ('Hamstrings', 'Hams'), ('Gluteus maximus', 'Glutes, Bum'), ('Calves', 'Calf'), ('Pectorals', 'Chest, Pecs'), ('Deltoids','Shoulders, Delts'),('Latissimus dorsi', 'Lats, Back, Upper-back'),('Lower-back', NULL),('Trapezius','Traps, Neck'), ('Abdominals', 'Core'),('Obliques', NULL), ('Biceps', 'Bis'), ('Triceps', 'Tris'), ('Forearm',NULL);

INSERT INTO [dbo].[Movement] ([MovementName], [PrimaryMuscleId], [SecondaryMuscles], [WeightTypeId], [DifficultyLevelId], [Description] ) VALUES 
('High Bar Squat', 1, 'Glutes, Hamstrings, Core', 1, 3, 'The high bar squat is a compound, full body exercise that trains primarily the muscles of the thighs, hips and buttocks, quadriceps (vastus lateralis, vastus medialis, vastus intermedius and rectus femoris), hamstrings, as well as strengthening the bones, ligaments and insertion of the tendons throughout the lower body.'),
('Barbell Bench Press', 5, 'Triceps, Shoulders, Core', 1, 2, 'The bench press is an upper body strength training exercise that consists of pressing a weight upwards from a supine position. The exercise works the pectoralis major as well as supporting chest, arm, and shoulder muscles like the anterior deltoids, serratus anterior, coracobrachialis, scapulae fixers, trapezii, and the triceps.'),
('Deadlift', 1, 'Glutes, Hamstrings, Lower-back, Core', 1, 3, 'The deadlift is a weight training exercise in which a loaded barbell is lifted off the ground to the hips, then lowered back to the ground. It is one of the three powerlifting exercises, along with the squat and bench press.'),
('Overhead Press', 6, 'Triceps, Core', 1, 2, 'The Overhead Press is a full body compound exercise that works your shoulders the most. You perform the Overhead Press by lifting the bar from your front shoulders overhead until your elbows are locked. Your knees and hips must remain locked through the whole movement.'),
('Bent Over Row', 7, 'Lower-back, Biceps, Core', 1, 2, 'A bent-over row (or barbell row) is a weight training exercise that targets a variety of back muscles. Which ones are targeted varies on form. The bent over row is often used for both bodybuilding and powerlifting. It is a good exercise for increasing strength and size.'),
('Incline Barbell Bench Press', 5, 'Triceps, Shoulders, Core', 1, 2, 'The incline bench press is an upper body strength training exercise that consists of pressing a weight upwards from a seated incline position. The exercise works the pectoralis major as well as supporting chest, arm, and shoulder muscles like the anterior deltoids, serratus anterior, coracobrachialis, scapulae fixers, trapezii, and the triceps.'),
('Decline Barbell Bench Press', 5, 'Triceps, Shoulders, Core', 1, 2, 'The decline bench press is an upper body strength training exercise that consists of pressing a weight upwards from a horizontal decline position. The exercise works the pectoralis major as well as supporting chest, arm, and shoulder muscles like the anterior deltoids, serratus anterior, coracobrachialis, scapulae fixers, trapezii, and the triceps.'),
('Seated Overhead Press', 6, 'Triceps, Core', 1, 2, 'The Overhead Press is a full body compound exercise that works your shoulders the most. You perform the seated overhead press sitting down and lifting the bar from your front shoulders overhead until your elbows are locked.'),
('Dumbbell Bench Press', 5, 'Triceps, Shoulders, Core', 2, 2, 'The bench press is an upper body strength training exercise that consists of pressing a weight upwards from a supine position. The exercise works the pectoralis major as well as supporting chest, arm, and shoulder muscles like the anterior deltoids, serratus anterior, coracobrachialis, scapulae fixers, trapezii, and the triceps.'),
('Incline Dumbbell Bench Press', 5, 'Triceps, Shoulders, Core', 2, 2, 'The incline bench press is an upper body strength training exercise that consists of pressing a weight upwards from a seated incline position. The exercise works the pectoralis major as well as supporting chest, arm, and shoulder muscles like the anterior deltoids, serratus anterior, coracobrachialis, scapulae fixers, trapezii, and the triceps.'),
('Decline Dumbbell Bench Press', 5, 'Triceps, Shoulders, Core', 2, 2, 'The decline bench press is an upper body strength training exercise that consists of pressing a weight upwards from a horizontal decline position. The exercise works the pectoralis major as well as supporting chest, arm, and shoulder muscles like the anterior deltoids, serratus anterior, coracobrachialis, scapulae fixers, trapezii, and the triceps.'),
('Dumbbell Shoulder Press', 6, 'Triceps, Core', 2, 2, 'The seated dumbbell shoulder press is a full body compound exercise that works your shoulders the most. You perform it seated by lifting the bar from your front shoulders overhead until your elbows are locked.'),
('Stiff Legged Deadlift', 2, 'Glutes, Quads, Lower-back, Core', 1, 3, 'The stiff legged deadlift is one of the best exercises to build overall hamstring development.'),
('Leg Press', 1, 'Glutes, Hamstrings, Lower-back, Core', 5, 1, 'The leg press is a weight training exercise in which the individual pushes a weight or resistance away from them using their legs.'),
('Standing Smith Calf Raises', 4, 'Glutes, Hamstrings', 5, 2, 'Smith calf raises allow you to isolate the calf muscles in an easy motion, simply pushing up off a raised surface with the smith machine bar across your back.'),
('Pull Ups', 7, 'Biceps', 4, 2, 'A pull-up is an upper-body compound pulling exercise. The pull-up is performed with a palms facing forward position.');

INSERT INTO [dbo].[Tempo] ([Eccentric],[Pause],[Concentric]) VALUES (2,0,1),(1,0,1);

INSERT INTO [dbo].[Set] ([MovementId], [SetNumber], [Reps], [Weight], [TempoId], [WeightPercentageId]) VALUES 
(1,1,8,82.5,1,2), (1,2,8,90,1,2), (1,3,8,95,1,2), (1,4,8,100,1,2), 
(13,5,8,60,1,2), (13,6,8,65,1,2), (13,7,8,70,1,2),
(14,8,10,60,1,2), (14,9,10,65,1,2), (14,10,10,70,1,2),
(15,11,15,60,1,2), (15,12,15,60,1,2), (15,13,15,60,1,2),
(2,1,8,82.5,1,2), (2,2,8,90,1,2), (2,3,8,95,1,2), (2,4,8,100,1,2),
(4,5,8,60,1,2), (4,6,8,65,1,2), (4,7,8,70,1,2),
(10,8,10,60,1,2), (10,9,10,65,1,2), (10,10,10,70,1,2),
(7,11,15,60,1,2), (7,12,15,60,1,2), (7,13,15,60,1,2),
(3,1,8,82.5,1,2), (3,2,8,90,1,2), (3,3,8,95,1,2), (3,4,8,100,1,2),
(5,5,8,60,1,2), (5,6,8,65,1,2), (5,7,8,70,1,2),
(10,8,10,60,1,2), (10,9,10,65,1,2), (10,10,10,70,1,2),
(16,11,15,0,1,2), (16,12,15,0,1,2), (16,13,15,0,1,2);

INSERT INTO [dbo].[Day] ([DayName]) VALUES ('Legs'), ('Push'), ('Pull'), ('Day 1 - Chest'), ('Day 2 - Legs'), ('Day 3 - Back & Bis'), ('Day 4 - Shoulders & Tris');

INSERT INTO [dbo].[DaySet] ([DayId],[SetId]) VALUES 
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),(1,13),
(2,14),(2,15),(2,16),(2,17),(2,18),(2,19),(2,20),(2,21),(2,22),(2,23),(2,24),(2,25),(2,26),
(3,27),(3,28),(3,29),(3,30),(3,31),(3,32),(3,33),(3,34),(3,35),(3,36),(3,37),(3,38),(3,39);

INSERT INTO [dbo].[Program] ([ProgramName],[FitnessGoalId],[Description]) VALUES 
('Legs/Push/Pull',0,'Repeat every four days with a rest day on the fourth.'), 
('4 Day Bodybuilding Routine',0,'A split often found in gym goers, designed to build all round muscle with each day designed to target a specific muscle group');

INSERT INTO [dbo].[ProgramDay] ([ProgramId],[DayId]) VALUES (1,1), (1,2), (1,3), (2,4), (2,5), (2,6), (2,7);

