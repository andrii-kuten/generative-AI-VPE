using GenerativeAI;
using Xunit;

namespace ConvertStudentsTestProject
{
    public class PlayerAnalyzerUnitTests
    {
        private readonly List<Player> _listOfPlayers;

        private readonly PlayerAnalyzer _playerAnalyzer;

        public PlayerAnalyzerUnitTests() 
        {
            _listOfPlayers = new List<Player>()
            {
                new Player()
                {
                    Name = "P1",
                    Age = 25,
                    Experience = 5,
                    Skills = new List<int>() { 2, 2, 2 }
                },
                new Player()
                {
                    Name = "P2",
                    Age = 15,
                    Experience = 3,
                    Skills = new List<int>() { 3, 3, 3 }
                },
                new Player()
                {
                    Name = "P3",
                    Age = 35,
                    Experience = 15,
                    Skills = new List<int>() { 4, 4, 4 }
                },
                new Player()
                {
                    Name = "P4",
                    Age = 35,
                    Experience = 15
                }
            };

            _playerAnalyzer = new PlayerAnalyzer();
        }

        // Should return 250 instead of given 150
        [Fact]
        public void NormalPlayer()
        {
            var data = _playerAnalyzer.CalculateScore(_listOfPlayers.Take(1).ToList());

            Assert.Equal(250, data);
        }

        [Fact]
        public void JuniorPlayer()
        {
            var data = _playerAnalyzer.CalculateScore(_listOfPlayers.Skip(1).Take(1).ToList());

            Assert.Equal(67.5, data);
        }

        // Should return 2520 instead of given 1008
        [Fact]
        public void SeniorPlayer()
        {
            var data = _playerAnalyzer.CalculateScore(_listOfPlayers.Skip(2).Take(1).ToList());

            Assert.Equal(2520, data);
        }

        [Fact]
        public void MultiplePlayers()
        {
            var data = _playerAnalyzer.CalculateScore(_listOfPlayers.Take(3).ToList());

            Assert.Equal(2837.5, data);
        }

        [Fact]
        public void SkillsIsNull()
        {
            Assert.Throws<ArgumentNullException>(() 
                => _playerAnalyzer.CalculateScore(_listOfPlayers));
        }

        [Fact]
        public void EmptyArray()
        {
            var data = _playerAnalyzer.CalculateScore(_listOfPlayers.Take(0).ToList());

            Assert.Equal(0, data);
        }
    }
}
