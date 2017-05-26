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
using System.Collections.Generic;
using System.Linq;
using System.Text;

[MoonSharpUserData]
public class GameState {

    private string playerName;
    private int buttonSelected;
    private HashSet<string> flags;
    private string portrait;

    [MoonSharpHidden]
    public GameState() {
        flags = new HashSet<string>();
    }

    public string PlayerName {
        get {
            return playerName;
        }
        [MoonSharpHidden]
        set {
            playerName = value;
        }
    }

    public int ButtonSelected {
        get {
            return buttonSelected;
        }
        [MoonSharpHidden]
        set {
            buttonSelected = value;
        }
    }

    public bool GetFlag(string flag) {
        return flags.Contains(flag);
    }

    public void SetFlag(string flag, bool set) {
        if(set) {
            flags.Add(flag);
        } else {
            flags.Remove(flag);
        }
    }
}

