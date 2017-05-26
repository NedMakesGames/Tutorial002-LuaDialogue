
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