using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Services
{
    public class TrainingVideoService
    {
        private string _path { get; set; }

        public TrainingVideoService(string path)
        {
            _path = path;
        }

        public IDictionary<string, string> List(string name)
        {
            return Directory.GetFiles(Path.Combine(_path, name)).ToDictionary((x) => new FileInfo(x).Name, (x) => $"{name}|{new FileInfo(x).Name}");
        }

        public IList<string> List()
        {
            return Directory.GetDirectories(_path).Select((x) => new DirectoryInfo(x).Name).ToList();
        }
    }
}
