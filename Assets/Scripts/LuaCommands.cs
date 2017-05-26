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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LuaCommands : MonoBehaviour {

    private static LuaCommands instance;

    [SerializeField]
    private Text uiText;

    private ButtonHandler buttons;
    private PortraitHandler portrait;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        buttons = FindObjectOfType<ButtonHandler>();
        portrait = FindObjectOfType<PortraitHandler>();
    }

    public static void SetText(string textString) {
        instance.uiText.text = textString;
    }

    public static void ShowButtons(string btn1TextString, string btn2TextString) {
        instance.buttons.ShowButtons(btn1TextString, btn2TextString);
    }

    public static void SetPortrait(string portraitType) {
        instance.portrait.SetPortrait(portraitType);
    }
}
