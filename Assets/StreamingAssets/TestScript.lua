-- Copyright (c) 2017, Timothy Ned Atton.
-- All rights reserved.
-- nedmakesgames@gmail.com
-- This code was written while streaming on twitch.tv/nedmakesgames
--
-- This file is part of Lua Dialogue.
--
-- Lua Dialogue is free software: you can redistribute it and/or modify
-- it under the terms of the GNU General Public License as published by
-- the Free Software Foundation, either version 3 of the License, or
-- (at your option) any later version.
--
-- Lua Dialogue is distributed in the hope that it will be useful,
-- but WITHOUT ANY WARRANTY; without even the implied warranty of
-- MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
-- GNU General Public License for more details.
--
-- You should have received a copy of the GNU General Public License
-- along with Lua Dialogue.  If not, see <http://www.gnu.org/licenses/>.

local helloBranch = function()
	SetText("Third slide")
	State.SetFlag("FirstButton", true)
	
	coroutine.yield()
	
	SetText("Last inner coroutine line!")
end

local main = function()

	SetPortrait("Talk")
	SetText("Hi "..State.PlayerName.."! I'm a Lua script!")
	ShowButtons("Hello", "Goodbye")
	
	coroutine.yield()
	
	if State.ButtonSelected == 1 then
		SetText("Second slide")
		coroutine.yield(helloBranch)
	else
		SetPortrait("Surprised")
		SetText("Other option")
		coroutine.yield()
	end
	
	if State.GetFlag("FirstButton") then
		SetPortrait("Annoyed")
		SetText("Flag was set")
	end
end

return main