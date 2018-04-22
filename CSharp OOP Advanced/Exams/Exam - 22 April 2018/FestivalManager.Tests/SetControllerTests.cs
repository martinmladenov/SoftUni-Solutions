// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using System;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Instruments;
    using Entities.Sets;

    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void PerformSets_CannotPerform_OrderedCorrectly()
        {
            IStage stage = new Stage();

            ISet shortSet = new Short("short");
            ISet mediumSet = new Medium("medium");
            ISet longSet = new Long("long");

            longSet.AddSong(new Song("s1", new TimeSpan(0, 2, 0)));
            mediumSet.AddSong(new Song("s2", new TimeSpan(0, 2, 0)));
            shortSet.AddSong(new Song("s3", new TimeSpan(0, 1, 0)));

            mediumSet.AddPerformer(new Performer("penka", 123));

            stage.AddSet(shortSet);
            stage.AddSet(longSet);
            stage.AddSet(mediumSet);

            ISetController setController = new SetController(stage);

            string actualResult = setController.PerformSets();
            string expectedResult =
                "1. medium:\r\n-- Did not perform\r\n2. long:\r\n-- Did not perform\r\n3. short:\r\n-- Did not perform";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PerformSets_CannotPerform_InstrumentDoesNotWearDown()
        {
            IStage stage = new Stage();

            ISet set = new Long("short");

            set.AddSong(new Song("s2", new TimeSpan(0, 1, 0)));

            IPerformer performer = new Performer("pesho", 100);

            IInstrument instrument = new Drums();

            performer.AddInstrument(instrument);

            set.AddPerformer(performer);

            set.AddPerformer(new Performer("gosho", 34));

            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            setController.PerformSets();

            double actualResult = instrument.Wear;
            double expectedResult = 100;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PerformSets_CanPerform_InstrumentWearsDown()
        {
            IStage stage = new Stage();

            ISet set = new Long("short");

            set.AddSong(new Song("s2", new TimeSpan(0, 1, 0)));

            IPerformer performer = new Performer("pesho", 100);

            IInstrument instrument = new Drums();

            performer.AddInstrument(instrument);

            set.AddPerformer(performer);

            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            setController.PerformSets();

            double actualResult = instrument.Wear;
            double expectedResult = 80;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PerformSets_CanPerform_OrderedCorrectly()
        {
            IStage stage = new Stage();

            ISet shortSet = new Short("short");
            ISet mediumSet = new Medium("medium");
            ISet longSet = new Long("long");

            longSet.AddSong(new Song("s1", new TimeSpan(0, 2, 0)));
            mediumSet.AddSong(new Song("s2", new TimeSpan(0, 2, 0)));
            shortSet.AddSong(new Song("s3", new TimeSpan(0, 1, 0)));

            IPerformer medPerformer1 = new Performer("penka", 123);
            medPerformer1.AddInstrument(new Guitar());

            IPerformer medPerformer2 = new Performer("ivan", 23);
            medPerformer2.AddInstrument(new Guitar());
            medPerformer2.AddInstrument(new Drums());

            IPerformer shortPerformer = new Performer("pesho", 32);
            shortPerformer.AddInstrument(new Microphone());

            IPerformer longPerformer = new Performer("georgi", 211);
            longPerformer.AddInstrument(new Drums());

            longSet.AddPerformer(longPerformer);
            mediumSet.AddPerformer(medPerformer1);
            mediumSet.AddPerformer(medPerformer2);
            shortSet.AddPerformer(shortPerformer);

            stage.AddSet(shortSet);
            stage.AddSet(longSet);
            stage.AddSet(mediumSet);

            ISetController setController = new SetController(stage);

            string actualResult = setController.PerformSets();
            string expectedResult =
                "1. medium:\r\n-- 1. s2 (02:00)\r\n-- Set Successful\r\n2. long:\r\n-- 1. s1 (02:00)\r\n-- Set Successful\r\n3. short:\r\n-- 1. s3 (01:00)\r\n-- Set Successful";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


    }
}