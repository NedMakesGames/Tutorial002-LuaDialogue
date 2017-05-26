// Copyright (c) 2017, Timothy Ned Atton.
// All rights reserved.
// nedmakesgames@gmail.com
// This code was written while streaming on twitch.tv/nedmakesgames
//
// This file is part of Lua Dialogue.
//
// Lua Dialogue is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Lua Dialogue is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Lua Dialogue.  If not, see <http://www.gnu.org/licenses/>.

using MoonSharp.Interpreter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class LuaEnvironment : MonoBehaviour {

    [SerializeField]
    private string loadFile;

    private Script enviro;
    private Stack<MoonSharp.Interpreter.Coroutine> corStack;
    private GameState luaGameState;

    public GameState LuaGameState {
        get {
            return luaGameState;
        }
    }

    private void Awake() {
        luaGameState = new GameState();
    }

    //private void Start() {
    //    StartCoroutine(Setup());
    //}

    private IEnumerator Start() {
        Debug.Log("Load script");
        Script.DefaultOptions.DebugPrint = (s) => Debug.Log(s);
        UserData.RegisterAssembly();

        corStack = new Stack<MoonSharp.Interpreter.Coroutine>();
        enviro = new Script(CoreModules.Preset_SoftSandbox);
        enviro.Globals["SetText"] = (Action<string>)LuaCommands.SetText;
        enviro.Globals["ShowButtons"] = (Action<string, string>)LuaCommands.ShowButtons;
        enviro.Globals["SetPortrait"] = (Action<string>)LuaCommands.SetPortrait;
        enviro.Globals["State"] = UserData.Create(luaGameState);

        yield return 1;

        LoadFile(loadFile);
        AdvanceScript();
    }

    private void LoadFile(string fileName) {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        DynValue ret = DynValue.Nil;

        try {
            using(BufferedStream stream = new BufferedStream(new FileStream(filePath, FileMode.Open, FileAccess.Read))) {
                ret = enviro.DoStream(stream);
            }
        } catch (SyntaxErrorException ex) {
            Debug.LogError(ex.DecoratedMessage);
        }

        if(ret.Type == DataType.Function) {
            corStack.Push(enviro.CreateCoroutine(ret).Coroutine);
        }
    }

    public void AdvanceScript() {
        if(corStack.Count > 0) {
            try {
                MoonSharp.Interpreter.Coroutine active = corStack.Peek();
                DynValue ret = active.Resume();
                if(active.State == CoroutineState.Dead) {
                    corStack.Pop();
                    Debug.Log("Coroutine dead");
                }
                if(ret.Type == DataType.Function) {
                    corStack.Push(enviro.CreateCoroutine(ret).Coroutine);
                }
            } catch (ScriptRuntimeException ex) {
                Debug.LogError(ex.DecoratedMessage);
                corStack.Clear();
            }
        } else {
            Debug.Log("No active dialogue");
        }
    }
}

