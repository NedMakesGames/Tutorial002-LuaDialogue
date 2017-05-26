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

public class ButtonHandler : MonoBehaviour {

    [SerializeField]
    private GameObject buttonParent;
    [SerializeField]
    private Text button1Text;
    [SerializeField]
    private Text button2Text;

    private LuaEnvironment lua;

    private void Start() {
        lua = FindObjectOfType<LuaEnvironment>();
        buttonParent.SetActive(false);
    }

    public void ButtonClicked(int index) {
        Debug.Log("Button clicked " + index);

        lua.LuaGameState.ButtonSelected = index + 1;
        buttonParent.SetActive(false);
        lua.AdvanceScript();
    }

    public void ShowButtons(string btn1TextString, string btn2TextString) {
        button1Text.text = btn1TextString;
        button2Text.text = btn2TextString;
        buttonParent.gameObject.SetActive(true);
    }

    public bool AreButtonsVisible() {
        return buttonParent.gameObject.activeSelf;
    }
}
