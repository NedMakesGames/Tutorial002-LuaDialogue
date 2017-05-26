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

public class PortraitHandler : MonoBehaviour {

    public enum Portraits {
        None, Talk, Surprised, Annoyed
    }

    [SerializeField]
    private Image sprite;

    //private LuaEnvironment lua;
    private Animator animator;

    void Start() {
        //lua = FindObjectOfType<LuaEnvironment>();
        animator = sprite.GetComponent<Animator>();

        SetPortrait("");
    }

    public void SetPortrait(string portraitStr) {
        Portraits type = Portraits.None;
        switch(portraitStr.ToUpperInvariant()) {
        case "TALK":
        case "TALKING":
            type = Portraits.Talk;
            break;
        case "SURPRISED":
            type = Portraits.Surprised;
            break;
        case "ANNOYED":
            type = Portraits.Annoyed;
            break;
        }

        sprite.gameObject.SetActive(type != Portraits.None);
        if(type != Portraits.None) {
            switch(type) {
            case Portraits.Talk:
                animator.Play("Talking");
                break;
            case Portraits.Surprised:
                animator.Play("Surprised");
                break;
            case Portraits.Annoyed:
                animator.Play("Annoyed");
                break;
            }
        }
    }
}
