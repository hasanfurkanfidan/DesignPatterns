using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Command.Commands
{
    public class FileCreateInvoker
    {
        private  ITableButtonActionCommand _tableButtonActionCommand;
        private List<ITableButtonActionCommand> tableButtonActionCommands = new List<ITableButtonActionCommand>();
        public void SetCommand(ITableButtonActionCommand tableButtonActionCommand)
        {
            _tableButtonActionCommand = tableButtonActionCommand;
        }
        public void AddCommand(ITableButtonActionCommand tableButtonActionCommand)
        {
            tableButtonActionCommands.Add(tableButtonActionCommand);
        }
        public IActionResult CreateFile()
        {
            return _tableButtonActionCommand.Execute();
        }
        public List<IActionResult> CreateFiles()
        {
           return tableButtonActionCommands.Select(x => x.Execute()).ToList();
        }
    }
}
