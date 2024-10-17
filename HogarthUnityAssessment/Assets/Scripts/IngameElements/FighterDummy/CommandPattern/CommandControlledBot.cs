using HogarthAssessmentTest;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
public class CommandControlledBot : MonoBehaviour
{
    private Queue<Command> _commands = new Queue<Command>();
    private Command _currentCommand;

    private bool _isStopped;
    public void StopOperation() { 
        _commands.Clear();
        _currentCommand = null;
        _isStopped = true;
    }
	#region mono
	private void Update() {
        //ListenForCommand();
        ProcessCommand();
	}
	#endregion
	private void ProcessCommand() {
        if (_isStopped) {
            return;
        }
        if (_currentCommand != null && !_currentCommand.IsFinished) {
            return;
        }
        if (_commands.Any() == false) {
            return;
        }

        _currentCommand = _commands.Dequeue();
        _currentCommand.Execute();
    }
    public void AddCommand(Command command, bool clearAllCommand = false) {
        if (clearAllCommand) {
            _currentCommand = null;
            _commands.Clear();
		}

		_commands.Enqueue(command);
    }
}
