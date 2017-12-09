using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var db_rotations = new List<CropRotation>() {
                new CropRotation() { Name = "Rotation1", UID = new Guid("53ace7f6-6dcb-4bfc-9468-995c2c76983f")},
                new CropRotation() { Name = "Rotation2", UID = new Guid("d8d7dd12-016e-4154-b5ff-5bee37d792f9")},
                new CropRotation() { Name = "Rotation3", UID = new Guid("061da1ab-8d4b-4510-b026-0f20cb164dc5")},
            };
            var db_steps = new List<CropRotationStep>() {
                new CropRotationStep(){ CropName = "Weizen", Step = 0, FKCropRotation = new Guid("53ace7f6-6dcb-4bfc-9468-995c2c76983f")},
                new CropRotationStep(){ CropName = "Mais", Step = 1, FKCropRotation = new Guid("53ace7f6-6dcb-4bfc-9468-995c2c76983f")},
                new CropRotationStep(){ CropName = "Bohnen", Step = 2, FKCropRotation = new Guid("53ace7f6-6dcb-4bfc-9468-995c2c76983f")},

                new CropRotationStep(){ CropName = "Äpfel", Step = 0, FKCropRotation = new Guid("d8d7dd12-016e-4154-b5ff-5bee37d792f9")},
                new CropRotationStep(){ CropName = "Birnen", Step = 1, FKCropRotation = new Guid("d8d7dd12-016e-4154-b5ff-5bee37d792f9")},

                new CropRotationStep(){ CropName = "Gras", Step = 0, FKCropRotation = new Guid("061da1ab-8d4b-4510-b026-0f20cb164dc5")},
                new CropRotationStep(){ CropName = "Kleeblatt", Step = 1, FKCropRotation = new Guid("061da1ab-8d4b-4510-b026-0f20cb164dc5")},
            };
            var db_enttityXCropRotation = new List<EntityxCropRotation>() {
                new EntityxCropRotation() { FKEntity = new Guid("e8dcdcfa-32da-4f29-b765-af0adf69af72"), FKCropRotation = new Guid("53ace7f6-6dcb-4bfc-9468-995c2c76983f")},
                new EntityxCropRotation() { FKEntity = new Guid("e8dcdcfa-32da-4f29-b765-af0adf69af72"), FKCropRotation = new Guid("d8d7dd12-016e-4154-b5ff-5bee37d792f9")},
                new EntityxCropRotation() { FKEntity = new Guid("e8dcdcfa-32da-4f29-b765-af0adf69af72"), FKCropRotation = new Guid("061da1ab-8d4b-4510-b026-0f20cb164dc5")}
            };


            var result = from x in db_enttityXCropRotation
                         where x.FKEntity == new Guid("e8dcdcfa-32da-4f29-b765-af0adf69af72")
                         join r in db_rotations on x.FKCropRotation equals r.UID
                         join s in db_steps on x.FKCropRotation equals s.FKCropRotation
                         select new {
                             RotationId = r.UID,
                             CropName = s.CropName,
                             Name = r.Name,
                             Step = s.Step
                         };

            var grouped = from r in result
                          group r by new { name = r.RotationId, uid = r.Name };

            foreach (var rotation in grouped)
            {
                Console.WriteLine($"{rotation.Key.uid} {rotation.Key.name}");

                foreach (var step in rotation)
                {
                    Console.WriteLine($"{step.Step} {step.CropName}");
                }
            }
            
            Console.ReadLine();            
        }
    }

    public class CropRotation
    {
        public Guid UID { get; set; }

        public string Name { get; set; }
    }

    public class CropRotationStep
    {
        public Guid FKCropRotation { get; set; }

        public string CropName { get; set; }

        public int Step { get; set; }
    }

    public class EntityxCropRotation
    {
        public Guid FKEntity { get; set; }

        public Guid FKCropRotation { get; set; }
    }
}