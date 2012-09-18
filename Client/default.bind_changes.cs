//-----------------------------------------------------------------------------
// Simple Spellcasting resource
// Copyright Lukas Jørgensen, 2012
//-----------------------------------------------------------------------------

// This script points out all the changes made in default.bind.cs

// First in the movement keys:

//------------------------------------------------------------------------------
// Movement Keys
//------------------------------------------------------------------------------

$movementSpeed = 1; // m/s
// Added this
$moving = 1;

// Added this function
function setSpeed(%speed)
{
   if(%speed !$= "")
      $movementSpeed = %speed;
}

// Edited all these move functions
function moveleft(%val)
{
   $oldLeftAction = %val * $movementSpeed;
   if($moving)
   {
      $mvLeftAction = $oldLeftAction;
   }
}
// Edited all these move functions
function moveright(%val)
{
   $oldRightAction = %val * $movementSpeed;
   if($moving)
   {
      $mvRightAction = $oldRightAction;
   }
}
// Edited all these move functions
function moveforward(%val)
{
   $oldForwardAction = %val * $movementSpeed;
   if($moving)
   {
      $mvForwardAction = $oldForwardAction;
   }
}
// Edited all these move functions
function movebackward(%val)
{
   $oldBackwardAction = %val * $movementSpeed;
   if($moving)
   {
      $mvBackwardAction = $oldBackwardAction;
   }
}

//.....

//------------------------------------------------------------------------------
// Mouse Trigger
//------------------------------------------------------------------------------

// Instead of having mouseFire, fire some weapon instead it now fires the next 
//  spell and removes the indicator decal.
function mouseFire(%val)
{
   //$mvTriggerCount0++;
   if(%val && $nextSpell !$= "")
   {
      commandToServer('CastSpell', $nextSpell);
      $nextSpell = "";
      decalManagerRemoveDecal( $SpellDecal );
      $SpellDecal = "";
   }
}

//.....

// Added this to the end of default.bind.cs
moveMap.bind(keyboard, "g", castSpell1);
moveMap.bind(keyboard, "f", castSpell2);
moveMap.bind(keyboard, "e", castSpell3);
moveMap.bindCmd(keyboard, "r", "spellIndicator(\"Flamepillar\");");

function castSpell1(%val)
{
   if(%val)
      commandToServer('CastSpell', "Rogue");
}

function castSpell2(%val)
{
   if(%val)
      commandToServer('CastMobSpell', "Rogue");
}

function castSpell3(%val)
{
   if(%val)
      commandToServer('CastSpell', "Fireball");
}

function castSpell4(%val)
{
   if(%val)
      commandToServer('CastSpell', "Flamepillar");
}

function spellIndicator(%spell)
{
   if(%spell !$= "")
      $nextSpell = %spell;
   spawnIndicatorDecal();
}