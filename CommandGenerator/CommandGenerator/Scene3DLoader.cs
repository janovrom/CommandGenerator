using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandGenerator
{
    public partial class Scene3DLoader
    {

        private Dictionary<int, SharedCmd> _commands = new Dictionary<int, SharedCmd>();
        private IStatelessSession _session = new StatelessSession();
        private Scene scene = new Scene();

        public Scene3DLoader()
        {
            InitializeCommands();
        }

        partial void InitializeCommands();

    }

    internal interface IStatelessSession
    {

        IList<T> QueryOver<T>();

    }

    internal class StatelessSession : IStatelessSession
    {
        public StatelessSession()
        {
        }

        public IList<T> QueryOver<T>()
        {
            throw new Exception();
        }

    }
}
