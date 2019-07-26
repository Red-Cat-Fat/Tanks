ñ
LE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\GameController\GameManager.cs
	namespace 	
Game
 
. 
Controllers 
. 
GameControllers *
{ 
public 
class 
GameManager 
: 
SingletonBehaviour .
<. /
GameManager/ :
>: ;
{		 
private

 	

GameObject


 
_playerGameObject

 &
;

& '
private 	
List
 
< 

GameObject 
> 
_enemys "
=# $
new% (
List) -
<- .

GameObject. 8
>8 9
(9 :
): ;
;; <
public 
void	 
	SetPlayer 
( 

GameObject "
player# )
)) *
{ 
_playerGameObject 
= 
player 
; 
} 
public 

GameObject	 
GetPlayerGameObject '
(' (
)( )
{ 
return 	
_playerGameObject
 
; 
} 
public 
void	 
AddEnemy 
( 

GameObject !
enemy" '
)' (
{ 
_enemys 

.
 
Add 
( 
enemy 
) 
; 
} 
public 
void	 
DestroyEnemy 
( 

GameObject %
enemy& +
)+ ,
{ 
_enemys 

.
 
Remove 
( 
enemy 
) 
; 
} 
public!! 

GameObject!!	 
GetMinDistanceEnemy!! '
(!!' (
Vector3!!( /
position!!0 8
)!!8 9
{"" 

GameObject## 
returnValue## 
=## 
null##  
;##  !
var$$ 
minDistance$$ 
=$$ 
float$$ 
.$$ 
MaxValue$$ #
;$$# $
foreach&& 

(&& 
var&& 
enemy&& 
in&& 
_enemys&&  
)&&  !
{'' 
var(( 
distanceVector(( 
=(( 
enemy(( 
.(( 
	transform(( (
.((( )
position(() 1
-((2 3
position((4 <
;((< =
var)) 
sqrMagnitude)) 
=)) 
distanceVector)) %
.))% &
sqrMagnitude))& 2
;))2 3
if** 
(** 
sqrMagnitude** 
<** 
minDistance** "
)**" #
{++ 
returnValue,, 
=,, 
enemy,, 
;,, 
minDistance-- 
=-- 
sqrMagnitude-- 
;--  
}.. 
}// 
return11 	
returnValue11
 
;11 
}22 
}33 
}44 Ž
GE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\TanksInput\IInputType.cs
	namespace 	
Game
 
. 
Controllers 
. 

TanksInput %
{ 
public		 
enum		 
CommandInputType		 
{

 
none 
, 
Swipe 
, 
Click 
} 
public 
	interface 

IInputType 
{ 
bool 
	IsClicked 
( 
) 
; 
Vector3 	
GetDirectionVector3
 
( 
) 
;  
void 

CheckInput 
( 
) 
; 
} 
public 
abstract 
class 
BaseInputType $
:% &
MonoBehaviour' 4
,4 5

IInputType6 @
{ 
	protected 
Vector2 
LastInputVector2 $
;$ %
	protected 
bool 
Clicked 
= 
false  
;  !
public 
abstract	 
void 

CheckInput !
(! "
)" #
;# $
public 
virtual	 
Vector3 
GetDirectionVector3 ,
(, -
)- .
{ 
var 
	direction 
= 
new 
Vector3 
( 
LastInputVector2 /
./ 0
x0 1
,1 2
$num3 4
,4 5
LastInputVector26 F
.F G
yG H
)H I
;I J
return   	
	direction  
 
.   

normalized   
;   
}!! 
public## 
virtual##	 
bool## 
	IsClicked## 
(##  
)##  !
{$$ 
if%% 
(%% 
Clicked%% 
)%% 
{&& 
Clicked'' 
='' 
false'' 
;'' 
return(( 

true(( 
;(( 
})) 
return** 	
false**
 
;** 
}++ 
	protected-- 
static-- 
CommandInputType-- #
GetTypeCommand--$ 2
(--2 3
Vector2--3 :
inputVector2--; G
)--G H
{.. 
if// 
(// 
inputVector2// 
.// 
	magnitude// 
<// 
InputSettings// ,
.//, -!
ClickMagnitudeMaxSize//- B
)//B C
{00 
return11 

CommandInputType11 
.11 
Click11 !
;11! "
}22 
else33 
{44 
return55 

CommandInputType55 
.55 
Swipe55 !
;55! "
}66 
}77 
}99 
}:: ë
IE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\TanksInput\InputManager.cs
	namespace 	
Game
 
. 
Controllers 
. 

TanksInput %
{ 
public		 
enum		 
InputTypeEnum		 
{

 
Swipe 
, 

SwipeMouse 
, 
VirtualJoystick 
, 
VirtualJoystick2D 
} 
public 
class 
InputManager 
: 
SingletonBehaviour /
</ 0
InputManager0 <
>< =
{ 
[ 
SerializeField 
] 
private 
InputTypeEnum (!
_currentInputTypeEnum) >
=? @
InputTypeEnumA N
.N O
SwipeO T
;T U
private 	

IInputType
 
_currentInputType &
;& '
public 
void	 
SetCurrentInputType !
(! "

IInputType" ,
newInputType- 9
)9 :
{ 
_currentInputType 
= 
newInputType #
;# $
switch 	
(
 !
_currentInputTypeEnum  
)  !
{ 
case 
InputTypeEnum	 
. 
Swipe 
: 
_currentInputType 
= 
new 
SwipeInputType +
(+ ,
), -
;- .
break 

;
 
case 
InputTypeEnum	 
. 

SwipeMouse !
:! "
_currentInputType 
= 
new 
SwipeMouseInputType 0
(0 1
)1 2
;2 3
break 

;
 
case   
InputTypeEnum  	 
.   
VirtualJoystick   &
:  & '
_currentInputType!! 
=!! 
new!! $
VirtualJoystickInputType!! 5
(!!5 6
)!!6 7
;!!7 8
break"" 

;""
 
case## 
InputTypeEnum##	 
.## 
VirtualJoystick2D## (
:##( )
_currentInputType$$ 
=$$ 
new$$ &
VirtualJoystickInputType2D$$ 7
($$7 8
)$$8 9
;$$9 :
break%% 

;%%
 
default&& 
:&& 
throw'' 

new'' '
ArgumentOutOfRangeException'' *
(''* +
)''+ ,
;'', -
}(( 
})) 
public++ 
Vector3++	 
GetDirectionVector3++ $
(++$ %
)++% &
{,, 
return-- 	
_currentInputType--
 
.-- 
GetDirectionVector3-- /
(--/ 0
)--0 1
;--1 2
}.. 
public00 
bool00	 
	IsClicked00 
(00 
)00 
{11 
return22 	
_currentInputType22
 
.22 
	IsClicked22 %
(22% &
)22& '
;22' (
}33 
public55 
void55	 

CheckInput55 
(55 
)55 
{66 
_currentInputType77 
.77 

CheckInput77 
(77  
)77  !
;77! "
}88 
private:: 	
void::
 
Awake:: 
(:: 
):: 
{;; 
SetCurrentInputType<< 
(<< 
_currentInputType<< (
)<<( )
;<<) *
}== 
private?? 	
void??
 
Update?? 
(?? 
)?? 
{@@ 

CheckInputAA 
(AA 
)AA 
;AA 
}BB 
}CC 
}DD ß
KE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\TanksInput\SwipeInputType.cs
	namespace 	
Game
 
. 
Controllers 
. 

TanksInput %
{ 
public 
class 
SwipeInputType 
: $
VirtualJoystickInputType 7
{		 
public

 
override

	 
void

 

CheckInput

 !
(

! "
)

" #
{ 
if 
( 
Input 
. 
touches 
. 
Length 
> 
$num 
)  
{ 
CalculateInput 
( 
Input 
. 
GetTouch !
(! "
$num" #
)# $
.$ %
position% -
)- .
;. /
} 
else 
{ 
	IsTouched 
= 
false 
; 
} 
CheckClicked 
( 
) 
; 
} 
} 
} Œ
PE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\TanksInput\SwipeMouseInputType.cs
	namespace 	
Game
 
. 
Controllers 
. 

TanksInput %
{ 
public 
class 
SwipeMouseInputType !
:" #$
VirtualJoystickInputType$ <
{		 
public

 
override

	 
void

 

CheckInput

 !
(

! "
)

" #
{ 
if 
( 
Input 
. 
GetMouseButton 
( 
$num 
) 
) 
{ 
CalculateInput 
( 
Input 
. 
mousePosition &
)& '
;' (
} 
else 
{ 
	IsTouched 
= 
false 
; 
} 
CheckClicked 
( 
) 
; 
} 
} 
} í"
UE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\TanksInput\VirtualJoystickInputType.cs
	namespace 	
Game
 
. 
Controllers 
. 

TanksInput %
{ 
public		 
class		 $
VirtualJoystickInputType		 &
:		' (
BaseInputType		) 6
{

 
	protected 
bool 
	IsTouched 
= 
false "
;" #
	protected 
Vector2 
StartTouchVector2 %
;% &
	protected 
Vector2 
LastTouchVector2 $
;$ %
	protected 
bool 
JustClicked 
= 
false $
;$ %
private 	
float
 
	_keepTime 
= 
$num 
; 
public 
override	 
void 

CheckInput !
(! "
)" #
{ 
if 
( 
Input 
. 
GetMouseButton 
( 
$num 
) 
) 
{ 
CalculateInput 
( 
Input 
. 
mousePosition &
)& '
;' (
} 
else 
{ 
	IsTouched 
= 
false 
; 
LastInputVector2 
= 
Vector2 
. 
zero #
;# $
} 
CheckClicked 
( 
) 
; 
} 
	protected 
void 
CalculateInput 
(  
Vector2  '
inputVector2( 4
)4 5
{   
if!! 
(!! 
!!! 
	IsTouched!! 
)!! 
{"" 
StartTouchVector2## 
=## 
inputVector2## $
;##$ %
	IsTouched$$ 
=$$ 
true$$ 
;$$ 
}%% 
LastTouchVector2'' 
='' 
inputVector2'' "
;''" #
var(( 
swipe(( 
=(( 
LastTouchVector2(( 
-((  !
StartTouchVector2((" 3
;((3 4
var)) 
	typeInput)) 
=)) 
GetTypeCommand)) !
())! "
swipe))" '
)))' (
;))( )
switch** 	
(**
 
	typeInput** 
)** 
{++ 
case,, 
CommandInputType,,	 
.,, 
none,, 
:,, 
break-- 

;--
 
case.. 
CommandInputType..	 
... 
Swipe.. 
:..  
JustClicked// 
=// 
false// 
;// 
LastInputVector200 
=00 
swipe00 
;00 
break11 

;11
 
case22 
CommandInputType22	 
.22 
Click22 
:22  
JustClicked33 
=33 
true33 
;33 
break44 

;44
 
}55 
}66 
	protected88 
void88 
CheckClicked88 
(88 
)88 
{99 
if:: 
(:: 
	IsTouched:: 
):: 
{;; 
if<< 
(<< 
JustClicked<< 
)<< 
{== 
	_keepTime>> 
+=>> 
Time>> 
.>> 
	deltaTime>>  
;>>  !
if?? 
(?? 	
	_keepTime??	 
>?? 
InputSettings?? "
.??" #
ClickKeepTimeStart??# 5
)??5 6
{@@ 
ClickedAA 
=AA 
trueAA 
;AA 
JustClickedBB 
=BB 
falseBB 
;BB 
}CC 
}DD 
elseEE 
{FF 
	_keepTimeGG 
=GG 
$numGG 
;GG 
}HH 
}II 
elseJJ 
{KK 
	_keepTimeLL 
=LL 
$numLL 
;LL 
ifMM 
(MM 
JustClickedMM 
)MM 
{NN 
ClickedOO 
=OO 
trueOO 
;OO 
JustClickedPP 
=PP 
falsePP 
;PP 
}QQ 
}RR 
}SS 
}TT 
}UU Œ
WE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\TanksInput\VirtualJoystickInputType2D.cs
	namespace 	
Game
 
. 
Controllers 
. 

TanksInput %
{ 
public 
class &
VirtualJoystickInputType2D (
:) *$
VirtualJoystickInputType+ C
{ 
public		 
virtual			 
Vector2		 
GetDirectionVector2		 ,
(		, -
)		- .
{

 
return 	
LastInputVector2
 
. 

normalized %
;% &
} 
public 
override	 
Vector3 
GetDirectionVector3 -
(- .
). /
{ 
return 	
GetDirectionVector2
 
( 
) 
;  
} 
} 
} º
aE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\DamageControllers\ContactDamageController.cs
	namespace		 	
Game		
 
.		 
Controllers		 
.		 
Units		  
.		  !
DamageControllers		! 2
{

 
public 
class #
ContactDamageController %
:& '
MonoBehaviour( 5
,5 6
IDamageController7 H
{ 
private 	

DamageData
 
_damageData  
;  !
private 	
Action
 
< 

GameObject 
, 
float "
>" #
_setDamageEvent$ 3
;3 4
private 	
void
 
Start 
( 
) 
{ 
_damageData 
= 
GetComponent 
< 

DamageData (
>( )
() *
)* +
;+ ,
Log 
. 
CheckForNull 
( 
_damageData 
,  

gameObject! +
,+ ,
typeof- 3
(3 4

DamageData4 >
)> ?
)? @
;@ A
} 
private 	
void
 
OnCollisionEnter 
(  
	Collision  )
	collision* 3
)3 4
{ 
var 
targetGameObject 
= 
	collision #
.# $

gameObject$ .
;. /
if 
( 
targetGameObject 
!= 
null 
)  
{ #
OnCollisionOnGameObject 
( 
targetGameObject ,
), -
;- .
} 
} 
private 	
void
 
OnCollisionEnter2D !
(! "
Collision2D" -
	collision. 7
)7 8
{ 
var   
targetGameObject   
=   
	collision   #
.  # $

gameObject  $ .
;  . /
if!! 
(!! 
targetGameObject!! 
!=!! 
null!! 
)!!  
{"" #
OnCollisionOnGameObject## 
(## 
targetGameObject## ,
)##, -
;##- .
}$$ 
}%% 
private'' 	
void''
 #
OnCollisionOnGameObject'' &
(''& '

GameObject''' 1
targetGameObject''2 B
)''B C
{(( 
var)) 
healthSystem)) 
=)) 
targetGameObject)) &
.))& '
GetComponent))' 3
<))3 4
HealthSystem))4 @
>))@ A
())A B
)))B C
;))C D
if** 
(** 
healthSystem** 
==** 
null** 
)** 
{++ 
Destroy,, 
(,, 

gameObject,, 
),, 
;,, 
}-- 
	SetDamage.. 
(.. 
targetGameObject.. 
).. 
;.. 
}// 
public11 
void11	 
SetDamageEvent11 
(11 
Action11 #
<11# $

GameObject11$ .
,11. /
float110 5
>115 6
actionEvent117 B
)11B C
{22 
_setDamageEvent33 
+=33 
actionEvent33 !
;33! "
}44 
public66 
void66	 
	SetDamage66 
(66 

GameObject66 "
targetGameObject66# 3
)663 4
{77 
_setDamageEvent88 
?88 
.88 
Invoke88 
(88 
targetGameObject88 +
,88+ ,
_damageData88- 8
.888 9
	GetDamage889 B
(88B C
)88C D
)88D E
;88E F
Destroy99 

(99
 

gameObject99 
)99 
;99 
}:: 
};; 
}<< ê
[E:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\DamageControllers\IDamageController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
DamageControllers! 2
{ 
public 
	interface 
IDamageController #
{		 
void

 
SetDamageEvent

 
(

 
Action

 
<

 

GameObject

 '
,

' (
float

) .
>

. /
actionEvent

0 ;
)

; <
;

< =
void 
	SetDamage 
( 

GameObject 
targetGameObject ,
), -
;- .
} 
} “

]E:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\GunControllers\EnemyFireGunConrtoller.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
GunControllers! /
{ 
public 
class "
EnemyFireGunConrtoller $
:% &!
PhysicalGunController' <
{ 
public 
override	 
bool 
	IsCanFire  
(  !
)! "
{ 
var		 
gunPoint		 
=		 
GunData		 
.		 
GetGunPoint		 %
(		% &
)		& '
;		' (
return

 	
base


 
.

 
	IsCanFire

 
(

 
)

 
&& 
Physics 
. 
Raycast 
( 
gunPoint 
.  
	transform  )
.) *
position* 2
,2 3
gunPoint 
. 
	transform 
. 
forward 
,  
out 
var	 
hit 
, 
$num 	
,	 

$num 
) 
; 
} 
} 
} ™
UE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\GunControllers\IGunController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
GunControllers! /
{ 
public 
	interface 
IGunController  
{ 
bool		 
	IsCanFire		 
(		 
)		 
;		 
void

 
Fire

 
(

 
)

 
;

 
} 
} Ä
\E:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\GunControllers\PhysicalGunController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
GunControllers! /
{		 
public

 
abstract

 
class

 !
PhysicalGunController

 ,
:

- .
MonoBehaviour

/ <
,

< =
IGunController

> L
{ 
	protected 
GunData 
GunData 
; 
private 	
void
 
Start 
( 
) 
{ 
GunData 

= 
GetComponent 
< 
GunData !
>! "
(" #
)# $
;$ %
Log 
. 
CheckForNull 
( 
GunData 
, 

gameObject '
,' (
typeof) /
(/ 0
GunData0 7
)7 8
)8 9
;9 :
} 
private 	
void
 
Update 
( 
) 
{ 
GunData 

.
 
Reload 
( 
Time 
. 
	deltaTime  
)  !
;! "
} 
public 
virtual	 
bool 
	IsCanFire 
(  
)  !
{ 
return 	
GunData
 
. 
	IsCanFire 
( 
) 
; 
} 
public 
virtual	 
void 
Fire 
( 
) 
{ 
var   
bullet   
=   
GunData   
.   
	GetBullet   !
(  ! "
)  " #
;  # $
var!! 
gunPoint!! 
=!! 
GunData!! 
.!! 
GetGunPoint!! %
(!!% &
)!!& '
;!!' (
Instantiate"" 
("" 
bullet"" 
,"" 
gunPoint"" 
.""  
	transform""  )
."") *
position""* 2
,""2 3
gunPoint""4 <
.""< =
	transform""= F
.""F G
rotation""G O
)""O P
;""P Q
GunData## 

.##
 
Fire## 
(## 
)## 
;## 
}$$ 
}%% 
}&& ð
ZE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\GunControllers\PlayerGunController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
GunControllers! /
{ 
public		 
class		 
PlayerGunController		 !
:		" #!
PhysicalGunController		$ 9
,		9 :
IGunController		; I
{

 
public 
override	 
bool 
	IsCanFire  
(  !
)! "
{ 
return 	
InputManager
 
. 
Instance 
.  
	IsClicked  )
() *
)* +
&&, .
base/ 3
.3 4
	IsCanFire4 =
(= >
)> ?
;? @
} 
} 
} ê
[E:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\HealthControllers\IHealthController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
HealthControllers! 2
{ 
public 
	interface 
IHealthController #
{		 
void

 
AddDeadEvent

 
(

 
ref

 
Action

 
actionEvent

 *
)

* +
;

+ ,
void 
	SetDamage 
( 
float 
inputDamage "
)" #
;# $
bool 
IsDead 
( 
) 
; 
} 
} ñ
bE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\HealthControllers\StandartHealthController.cs
	namespace		 	
Game		
 
.		 
Controllers		 
.		 
Units		  
.		  !
HealthControllers		! 2
{

 
public 
class $
StandartHealthController &
:' (
MonoBehaviour) 6
,6 7
IHealthController8 I
{ 
private 	

HealthData
 
_healthData  
;  !
private 	
void
 
Start 
( 
) 
{ 
_healthData 
= 
GetComponent 
< 

HealthData (
>( )
() *
)* +
;+ ,
Log 
. 
CheckForNull 
( 
_healthData 
,  

gameObject! +
,+ ,
typeof- 3
(3 4

HealthData4 >
)> ?
)? @
;@ A
} 
public 
void	 
AddDeadEvent 
( 
ref 
Action %
actionEvent& 1
)1 2
{ 
actionEvent 
+= 
( 
) 
=> 
{ 
var 
destroyedGameObject 
= 
_healthData )
.) *"
GetDestroyedGameObject* @
(@ A
)A B
;B C
if 
( 
destroyedGameObject 
!= 
null #
)# $
{ 
Instantiate 
( 
destroyedGameObject $
,$ %
	transform& /
./ 0
position0 8
,8 9
	transform: C
.C D
rotationD L
)L M
;M N
} 
} 
; 
} 
public   
bool  	 
IsDead   
(   
)   
{!! 
return"" 	
_healthData""
 
."" 
IsDead"" 
("" 
)"" 
;"" 
}## 
public%% 
void%%	 
	SetDamage%% 
(%% 
float%% 
inputDamage%% )
)%%) *
{&& 
_healthData'' 
.'' 
	SetDamage'' 
('' 
inputDamage'' $
)''$ %
;''% &
}(( 
})) 
}** Ý#
ZE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\MoveControllers\BaseMoveController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
MoveControllers! 0
{ 
public 
abstract 
class 
BaseMoveController )
:* +
MonoBehaviour, 9
,9 :
IMoveController; J
{ 
	protected 
MoveData 
UnitMoveData !
;! "
	protected 
virtual 
void 
Start 
( 
)  
{ 
UnitMoveData 
= 
GetComponent 
< 
MoveData '
>' (
(( )
)) *
;* +
Log 
. 
CheckForNull 
( 
UnitMoveData  
,  !

gameObject" ,
,, -
typeof. 4
(4 5
MoveData5 =
)= >
)> ?
;? @
} 
public 
virtual	 
Vector3 
CulculateTarget (
(( )
)) *
{ 
return 	
	transform
 
. 
position 
; 
} 
public 
virtual	 
Vector3 "
GetNextPosirionVector3 /
(/ 0
Vector30 7
forwardVector38 F
)F G
{ 
var 
directionVector3 
= 
CulculateTarget )
() *
)* +
-, -
	transform. 7
.7 8
position8 @
;@ A
if 
( 
directionVector3 
== 
Vector3 "
." #
zero# '
)' (
return) /
	transform0 9
.9 :
position: B
;B C
var!! 
procent!! 
=!! 
Time!! 
.!! 
fixedDeltaTime!! $
/!!% &
$num!!' (
;!!( )
var"" 
speed"" 
="" 
UnitMoveData"" 
."" 
GetSpeedMove"" (
(""( )
)"") *
;""* +
var## 
newPositionVector3## 
=## 
	transform## %
.##% &
position##& .
+##/ 0
(##1 2
forwardVector3##2 @
*##A B
speed##C H
*##I J
procent##K R
)##R S
;##S T
return$$ 	
newPositionVector3$$
 
;$$ 
}%% 
public'' 
virtual''	 

Quaternion'' %
GetNextRotationQuaternion'' 5
(''5 6
Vector3''6 =
axisVector3''> I
)''I J
{(( 
var)) 
directionVector3)) 
=)) 
CulculateTarget)) )
())) *
)))* +
-)), -
	transform)). 7
.))7 8
position))8 @
;))@ A
if** 
(** 
directionVector3** 
==** 
Vector3** "
.**" #
zero**# '
)**' (
return**) /
	transform**0 9
.**9 :
rotation**: B
;**B C
var,, 
rotationAngle,, 
=,, 
Mathf,, 
.,, 
Atan2,, "
(,," #
directionVector3,,# 3
.,,3 4
y,,4 5
,,,5 6
directionVector3,,7 G
.,,G H
x,,H I
),,I J
;,,J K
rotationAngle-- 
=-- 
rotationAngle--  
*--! "
Mathf--# (
.--( )
Rad2Deg--) 0
;--0 1
var.. 
rotation.. 
=.. 

Quaternion.. 
... 
	AngleAxis.. &
(..& '
rotationAngle..' 4
,..4 5
axisVector3..6 A
)..A B
;..B C
var00 
teleportToRotation00 
=00 

Quaternion00 &
.00& '
Slerp00' ,
(00, -
	transform00- 6
.006 7
rotation007 ?
,00? @
rotation00A I
,00I J
Time00K O
.00O P
fixedDeltaTime00P ^
*00_ `
UnitMoveData00a m
.00m n
GetSpeedRotation00n ~
(00~ 
)	00 €
)
00€ 
;
00 ‚
return11 	
teleportToRotation11
 
;11 
}22 
}33 
}44 ß
cE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\MoveControllers\EnemyFollowPlayerController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
MoveControllers! 0
{ 
public 
class '
EnemyFollowPlayerController )
:* +
BaseMoveController, >
{ 
[		 
SerializeField		 
]		 
private		 

GameObject		 %
_player		& -
;		- .
public

 
override

	 
Vector3

 
CulculateTarget

 )
(

) *
)

* +
{ 
return 	
_player
 
. 
	transform 
. 
position $
;$ %
} 
} 
} ˜
^E:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\MoveControllers\FollowPlayerController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
MoveControllers! 0
{ 
public		 
class		 "
FollowPlayerController		 $
:		% &
BaseMoveController		' 9
{

 
public 
override	 
Vector3 
CulculateTarget )
() *
)* +
{ 
var 
player 
= 
GameManager 
. 
Instance $
.$ %
GetPlayerGameObject% 8
(8 9
)9 :
;: ;
return 	
player
 
. 
	transform 
. 
position #
;# $
} 
} 
} †
WE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\MoveControllers\IMoveController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
MoveControllers! 0
{ 
public 
	interface 
IMoveController !
{ 
Vector3		 	
CulculateTarget		
 
(		 
)		 
;		 
Vector3

 	"
GetNextPosirionVector3


  
(

  !
Vector3

! (
forwardVector3

) 7
)

7 8
;

8 9

Quaternion %
GetNextRotationQuaternion &
(& '
Vector3' .
axisVector3/ :
): ;
;; <
} 
}  
aE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\MoveControllers\MetalBulletMoveController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
MoveControllers! 0
{ 
public 
class %
MetalBulletMoveController '
:( )
MonoBehaviour* 7
,7 8
IMoveController9 H
{ 
private		 	
MoveData		
 
	_moveData		 
;		 
private

 	
void


 
Start

 
(

 
)

 
{ 
	_moveData 
= 
GetComponent 
< 
MoveData $
>$ %
(% &
)& '
;' (
Log 
. 
CheckForNull 
( 
	_moveData 
, 

gameObject )
,) *
typeof+ 1
(1 2
MoveData2 :
): ;
); <
;< =
} 
public 
Vector3	 
CulculateTarget  
(  !
)! "
{ 
return 	
	_moveData
 
. &
GetForwardDirectionVector3 .
(. /
	transform/ 8
)8 9
*: ;
Time< @
.@ A
fixedDeltaTimeA O
*P Q
	_moveDataR [
.[ \
GetSpeedMove\ h
(h i
)i j
;j k
} 
public 
Vector3	 "
GetNextPosirionVector3 '
(' (
Vector3( /
forwardVector30 >
)> ?
{ 
return 	
	transform
 
. 
position 
+ 
CulculateTarget .
(. /
)/ 0
;0 1
} 
public 

Quaternion	 %
GetNextRotationQuaternion -
(- .
Vector3. 5
axisVector36 A
)A B
{ 
return 	
	transform
 
. 
rotation 
; 
} 
} 
} ›8
\E:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\MoveControllers\PlayerMoveController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
MoveControllers! 0
{		 
public

 
enum

  
TypePlayerController

 !
{ 
FirstPerson 
, 
ThridPerson 
, 
TopDown 	
} 
public 
class  
PlayerMoveController "
:# $
BaseMoveController% 7
{ 
public  
TypePlayerController	 '
CurrentTypePlayerController 9
=: ; 
TypePlayerController< P
.P Q
ThridPersonQ \
;\ ]
public 
override	 
Vector3 
CulculateTarget )
() *
)* +
{ 
var 
directionMoveVector 
= 
InputManager )
.) *
Instance* 2
.2 3
GetDirectionVector33 F
(F G
)G H
;H I
return 	
ConvertToXPerson
 
( 
directionMoveVector .
). /
+0 1
	transform2 ;
.; <
position< D
;D E
} 
public 
override	 
Vector3 "
GetNextPosirionVector3 0
(0 1
Vector31 8
forwardVector39 G
)G H
{ 
var 
directionVector3 
= 
CulculateTarget )
() *
)* +
-, -
	transform. 7
.7 8
position8 @
;@ A
if 
( 
directionVector3 
== 
Vector3 "
." #
zero# '
)' (
return) /
	transform0 9
.9 :
position: B
;B C
var    
directionForwardBack   
=   
Vector3   %
.  % &
Dot  & )
(  ) *
forwardVector3  * 8
,  8 9
directionVector3  : J
)  J K
<=!!  
Settings!!! )
.!!) *
InputSettings!!* 7
.!!7 8%
StepInJoystickByBackMoved!!8 Q
?!!R S
-!!T U
$num!!U V
:!!W X
$num!!Y Z
;!!Z [
var"" 
procent"" 
="" 
Time"" 
."" 
fixedDeltaTime"" $
/""% &
$num""' (
*"") * 
directionForwardBack""+ ?
;""? @
var## 
speed## 
=## 
UnitMoveData## 
.## 
GetSpeedMove## (
(##( )
)##) *
;##* +
var$$ 
newPositionVector3$$ 
=$$ 
	transform$$ %
.$$% &
position$$& .
+$$/ 0
($$1 2
forwardVector3$$2 @
*$$A B
speed$$C H
*$$I J
procent$$K R
)$$R S
;$$S T
return%% 	
newPositionVector3%%
 
;%% 
}&& 
public)) 
override))	 

Quaternion)) %
GetNextRotationQuaternion)) 6
())6 7
Vector3))7 >
axisVector3))? J
)))J K
{** 
var++ 
directionVector3++ 
=++ 
CulculateTarget++ )
(++) *
)++* +
-++, -
	transform++. 7
.++7 8
position++8 @
;++@ A
if,, 
(,, 
directionVector3,, 
==,, 
Vector3,, "
.,," #
zero,,# '
),,' (
return,,) /
	transform,,0 9
.,,9 :
rotation,,: B
;,,B C
var.. 
	direction.. 
=.. 
Vector3.. 
... 
Dot.. 
(.. 
UnitMoveData.. +
...+ ,&
GetForwardDirectionVector3.., F
(..F G
	transform..G P
)..P Q
,..Q R
directionVector3..S c
)..c d
<=// 
Settings// 
.// 
InputSettings// ,
.//, -%
StepInJoystickByBackMoved//- F
?//G H
-//I J
$num//J K
://L M
$num//N O
;//O P
var11 
rotationAngle11 
=11 
Mathf11 
.11 
Atan211 "
(11" #
directionVector311# 3
.113 4
y114 5
,115 6
directionVector3117 G
.11G H
x11H I
)11I J
;11J K
rotationAngle22 
=22 
rotationAngle22  
*22! "
Mathf22# (
.22( )
Rad2Deg22) 0
;220 1
var33 
rotation33 
=33 

Quaternion33 
.33 
	AngleAxis33 &
(33& '
rotationAngle33' 4
+335 6
(337 8
	direction338 A
==33B D
-33E F
$num33F G
?33H I
$num33J M
:33N O
$num33P Q
)33Q R
,33R S
axisVector333T _
)33_ `
;33` a
var55 
teleportToRotation55 
=55 

Quaternion55 &
.55& '
Slerp55' ,
(55, -
	transform55- 6
.556 7
rotation557 ?
,55? @
rotation55A I
,55I J
Time55K O
.55O P
fixedDeltaTime55P ^
*55_ `
UnitMoveData55a m
.55m n
GetSpeedRotation55n ~
(55~ 
)	55 €
)
55€ 
;
55 ‚
return66 	
teleportToRotation66
 
;66 
}77 
private99 	
Vector399
 
ConvertToXPerson99 "
(99" #
Vector399# *
directionMoveVector99+ >
)99> ?
{:: 
switch;; 	
(;;
 '
CurrentTypePlayerController;; &
);;& '
{<< 
case==  
TypePlayerController==	 
.== 
FirstPerson== )
:==) *
return>> 
directionMoveVector>> 
;>>  
case??  
TypePlayerController??	 
.?? 
ThridPerson?? )
:??) *
var@@ 
resultVector@@	 
=@@ 
UnitMoveData@@ $
.@@$ %&
GetForwardDirectionVector3@@% ?
(@@? @
	transform@@@ I
)@@I J
*@@K L
directionMoveVector@@M `
.@@` a
z@@a b
+AA 
	transformAA #
.AA# $
rightAA$ )
*AA* +
directionMoveVectorAA, ?
.AA? @
xAA@ A
;AAA B
returnBB 
resultVectorBB 
;BB 
caseCC  
TypePlayerControllerCC	 
.CC 
TopDownCC %
:CC% &
returnDD 
directionMoveVectorDD 
;DD  
defaultEE 
:EE 
returnFF 
directionMoveVectorFF 
;FF  
}GG 
}HH 
}II 
}JJ Þ

bE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\MoveControllers\PlayerTurretMoveController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
MoveControllers! 0
{ 
public 
class &
PlayerTurretMoveController (
:) *
BaseMoveController+ =
{		 
public

 
override

	 
Vector3

 
CulculateTarget

 )
(

) *
)

* +
{ 
var 
target 
= 
GameManager 
. 
Instance $
.$ %
GetMinDistanceEnemy% 8
(8 9
	transform9 B
.B C
positionC K
)K L
;L M
var 
	direction 
= 
target 
!= 
null !
? 
target 
. 
	transform 
. 
position 
: 
UnitMoveData 
. &
GetForwardDirectionVector3 -
(- .
	transform. 7
)7 8
+9 :
	transform; D
.D E
positionE M
;M N
return 	
	direction
 
; 
} 
} 
} ñ

[E:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\TeamControllers\EnemyTeamController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
TeamControllers! 0
{ 
public		 
class		 
EnemyTeamController		 !
:		" #
MonoBehaviour		$ 1
,		1 2
ITeamController		3 B
{

 
public 
void	 
InitialAction 
( 
) 
{ 
GameManager 
. 
Instance 
. 
AddEnemy  
(  !

gameObject! +
)+ ,
;, -
var 
healthSystem 
= 
GetComponent "
<" #
HealthSystem# /
>/ 0
(0 1
)1 2
;2 3
if 
( 
healthSystem 
!= 
null 
) 
{ 
healthSystem 
. 
AddDeadEvent 
( 
( 
)  
=>! #
GameManager$ /
./ 0
Instance0 8
.8 9
DestroyEnemy9 E
(E F

gameObjectF P
)P Q
)Q R
;R S
} 
} 
} 
} Ð
WE:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\TeamControllers\ITeamController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
TeamControllers! 0
{ 
public 
	interface 
ITeamController !
{ 
void		 
InitialAction		 
(		 
)		 
;		 
}

 
} ø
\E:\Tanks\Tanks\Assets\Scripts\Game\Controllers\Units\TeamControllers\PlayerTeamController.cs
	namespace 	
Game
 
. 
Controllers 
. 
Units  
.  !
TeamControllers! 0
{ 
public 
class  
PlayerTeamController "
:# $
MonoBehaviour% 2
,2 3
ITeamController4 C
{		 
public

 
void

	 
InitialAction

 
(

 
)

 
{ 
GameManager 
. 
Instance 
. 
	SetPlayer !
(! "

gameObject" ,
), -
;- .
} 
} 
} ¬
<E:\Tanks\Tanks\Assets\Scripts\Game\Datas\Units\DamageData.cs
	namespace 	
Game
 
. 
Data 
. 
Units 
{ 
public 
class 

DamageData 
: 
MonoBehaviour (
{ 
[		 
SerializeField		 
]		 
private		 
float		  
_damageValue		! -
=		. /
$num		0 4
;		4 5
public 
float	 
	GetDamage 
( 
) 
{ 
return 	
_damageValue
 
; 
} 
} 
} ð
9E:\Tanks\Tanks\Assets\Scripts\Game\Datas\Units\GunData.cs
	namespace 	
Game
 
. 
Data 
. 
Units 
{ 
public 
class 
GunData 
: 
MonoBehaviour %
{ 
private 	
float
 
_cooldownTime 
= 
$num  "
;" #
[ 
SerializeField 
] 
private 
float  
_reloadTime! ,
=- .
$num/ 1
;1 2
[		 
SerializeField		 
]		 
private		 

GameObject		 %
_bullet		& -
;		- .
[

 
SerializeField

 
]

 
private

 

GameObject

 %
	_gunPoint

& /
;

/ 0
public 
void	 
Reload 
( 
float 
time 
)  
{ 
_cooldownTime 
-= 
time 
; 
} 
public 
void	 
Fire 
( 
) 
{ 
_cooldownTime 
= 
_reloadTime 
; 
} 
public 

GameObject	 
	GetBullet 
( 
) 
{ 
return 	
_bullet
 
; 
} 
public 

GameObject	 
GetGunPoint 
(  
)  !
{ 
return 	
	_gunPoint
 
; 
} 
public   
bool  	 
	IsCanFire   
(   
)   
{!! 
return"" 	
_cooldownTime""
 
<"" 
$num"" 
;"" 
}## 
}$$ 
}%% ˆ
<E:\Tanks\Tanks\Assets\Scripts\Game\Datas\Units\HealthData.cs
	namespace 	
Game
 
. 
Data 
. 
Units 
{ 
public 
class 

HealthData 
: 
MonoBehaviour (
{ 
[		 
SerializeField		 
]		 
private		 
float		  
_healthPoint		! -
=		. /
$num		0 4
;		4 5
[

 
SerializeField

 
]

 
private

 

GameObject

 % 
_destroyedGameObject

& :
;

: ;
public 
void	 
	SetHealth 
( 
float 
value #
)# $
{ 
_healthPoint 
= 
value 
; 
} 
public 
void	 
	SetDamage 
( 
float 
value #
)# $
{ 
_healthPoint 
-= 
value 
; 
} 
public 
bool	 
IsDead 
( 
) 
{ 
return 	
_healthPoint
 
<= 
$num 
; 
} 
public 

GameObject	 "
GetDestroyedGameObject *
(* +
)+ ,
{ 
return 	 
_destroyedGameObject
 
; 
} 
} 
}   º&
:E:\Tanks\Tanks\Assets\Scripts\Game\Datas\Units\MoveData.cs
	namespace 	
Game
 
. 
Data 
. 
Units 
{ 
public 
enum 
VectorDirectionType  
{		 
Forward

 	
,

	 

Right 
, 
Up 
} 
public 
class 
MoveData 
: 
MonoBehaviour &
{ 
[ 
SerializeField 
] 
private 
bool 
_isOnlyRotate  -
=. /
false0 5
;5 6
[ 
SerializeField 
] 
private 
float  

_speedMove! +
=, -
$num. 0
;0 1
[ 
SerializeField 
] 
private 
float  
_speedRotation! /
=0 1
$num2 4
;4 5
[ 
SerializeField 
] 
private 
VectorDirectionType .'
_vectorForwardDirectionType/ J
=K L
VectorDirectionTypeM `
.` a
Forwarda h
;h i
[ 
SerializeField 
] 
private 
VectorDirectionType .&
_vectorNormalDirectionType/ I
=J K
VectorDirectionTypeL _
._ `
Up` b
;b c
public 
float	 
GetSpeedMove 
( 
) 
{ 
return 	

_speedMove
 
; 
} 
public 
float	 
GetSpeedRotation 
(  
)  !
{ 
return 	
_speedRotation
 
; 
} 
public   
Vector3  	 &
GetForwardDirectionVector3   +
(  + ,
)  , -
{!! 
switch"" 	
(""
 '
_vectorForwardDirectionType"" &
)""& '
{## 
case$$ 
VectorDirectionType$$	 
.$$ 
Forward$$ $
:$$$ %
return%% 
Vector3%% 
.%% 
forward%% 
;%% 
case&& 
VectorDirectionType&&	 
.&& 
Right&& "
:&&" #
return'' 
Vector3'' 
.'' 
right'' 
;'' 
default(( 
:(( 
throw)) 

new)) '
ArgumentOutOfRangeException)) *
())* +
)))+ ,
;)), -
}** 
}++ 
public-- 
Vector3--	 &
GetForwardDirectionVector3-- +
(--+ ,
	Transform--, 5
	transform--6 ?
)--? @
{.. 
switch// 	
(//
 '
_vectorForwardDirectionType// &
)//& '
{00 
case11 
VectorDirectionType11	 
.11 
Forward11 $
:11$ %
return22 
	transform22 
.22 
forward22 
;22 
case33 
VectorDirectionType33	 
.33 
Right33 "
:33" #
return44 
	transform44 
.44 
right44 
;44 
case55 
VectorDirectionType55	 
.55 
Up55 
:55  
return66 
	transform66 
.66 
up66 
;66 
default77 
:77 
throw88 

new88 '
ArgumentOutOfRangeException88 *
(88* +
)88+ ,
;88, -
}99 
}:: 
public<< 
Vector3<<	 %
GetNormalDirectionVector3<< *
(<<* +
)<<+ ,
{== 
switch>> 	
(>>
 &
_vectorNormalDirectionType>> %
)>>% &
{?? 
case@@ 
VectorDirectionType@@	 
.@@ 
Forward@@ $
:@@$ %
returnAA 
Vector3AA 
.AA 
forwardAA 
;AA 
caseBB 
VectorDirectionTypeBB	 
.BB 
RightBB "
:BB" #
returnCC 
Vector3CC 
.CC 
rightCC 
;CC 
caseDD 
VectorDirectionTypeDD	 
.DD 
UpDD 
:DD  
returnEE 
Vector3EE 
.EE 
upEE 
;EE 
defaultFF 
:FF 
throwGG 

newGG '
ArgumentOutOfRangeExceptionGG *
(GG* +
)GG+ ,
;GG, -
}HH 
}II 
publicKK 
boolKK	 
GetIsOnlyRoteteKK 
(KK 
)KK 
{LL 
returnMM 	
_isOnlyRotateMM
 
;MM 
}NN 
}OO 
}PP œ
:E:\Tanks\Tanks\Assets\Scripts\Game\Datas\Units\TeamData.cs
	namespace 	
Game
 
. 
Data 
. 
Units 
{ 
public 
enum 
TeamType 
{ 
Player		 
,		 	
Computer

 

} 
public 
class 
TeamData 
: 
MonoBehaviour &
{ 
[ 
SerializeField 
] 
private 
TeamType #
	_teamType$ -
;- .
public 
TeamType	 
GetTeamType 
( 
) 
{ 
return 	
	_teamType
 
; 
} 
} 
} °
DE:\Tanks\Tanks\Assets\Scripts\Game\HelpModules\SingletonBehaviour.cs
	namespace 	
Game
 
. 
HelpModules 
{ 
public 
class 
SingletonBehaviour  
<  !
T! "
>" #
:$ %
MonoBehaviour& 3
where 
T 	
:
 
SingletonBehaviour 
< 
T  
>  !
{		 
private 	
static
 
T 
	_instance 
; 
public 
static	 
T 
Instance 
=> 
	_instance '
==( *
null+ /
?0 1
	_instance2 ;
=< =
FindObjectOfType> N
<N O
TO P
>P Q
(Q R
)R S
:T U
	_instanceV _
;_ `
} 
} ¹
KE:\Tanks\Tanks\Assets\Scripts\Game\Renderer\Camera\CameraTags\ICameraTag.cs
	namespace 	
Game
 
. 
Renderer 
. 
Camera 
. 

CameraTags )
{ 
public 
	interface 

ICameraTag 
{ 

GameObject		 
GetPoint		 
(		 
)		 
;		 
}

 
} î
PE:\Tanks\Tanks\Assets\Scripts\Game\Renderer\Camera\CameraTags\PlayerCameraTag.cs
	namespace 	
Game
 
. 
Renderer 
. 
Camera 
. 

CameraTags )
{ 
public 
class 
PlayerCameraTag 
: 
MonoBehaviour  -
,- .

ICameraTag/ 9
{ 
public 

GameObject	 
GetPoint 
( 
) 
{		 
return

 	

gameObject


 
;

 
} 
} 
} Á
FE:\Tanks\Tanks\Assets\Scripts\Game\Renderer\Camera\FollowCameraData.cs
	namespace 	
Game
 
. 
Renderer 
. 
Camera 
{ 
public 
class 
FollowCameraData 
:  
MonoBehaviour! .
{ 
[ 
SerializeField 
] 
private 
bool 
	_isRotate  )
=* +
true, 0
;0 1
[ 
SerializeField 
] 
private 

GameObject %
_anchorPoint& 2
;2 3
[		 
SerializeField		 
]		 
private		 

GameObject		 %
_followObject		& 3
;		3 4
[

 
SerializeField

 
]

 
private

 
float

  

_moveSpeed

! +
;

+ ,
[ 
SerializeField 
] 
private 
float  
_rotateSpeed! -
;- .
public 

GameObject	 
GetAnchorPoint "
(" #
)# $
{ 
return 	
_anchorPoint
 
; 
} 
public 
void	 
SetAnchorPoint 
( 

GameObject '
anchorPoint( 3
)3 4
{ 
_anchorPoint 
= 
anchorPoint 
; 
} 
public 

GameObject	 
GetFollowObject #
(# $
)$ %
{ 
return 	
	_isRotate
 
? 
_followObject #
:$ %
null& *
;* +
} 
public 
float	 
GetMoveSpeed 
( 
) 
{ 
return 	

_moveSpeed
 
; 
} 
public!! 
float!!	 
GetRotateSpeed!! 
(!! 
)!! 
{"" 
return## 	
	_isRotate##
 
?## 
_rotateSpeed## "
:### $
$num##% &
;##& '
}$$ 
}%% 
}&& æ'
HE:\Tanks\Tanks\Assets\Scripts\Game\Renderer\Camera\FollowCameraSystem.cs
	namespace 	
Game
 
. 
Renderer 
. 
Camera 
{ 
public 
class 
FollowCameraSystem  
:! "
MonoBehaviour# 0
{ 
private 	
FollowCameraData
 
_followCameraData ,
;, -
private		 	
Vector3		
 +
_lastAnchorPointPositionVector3		 1
;		1 2
private

 	
float


 
	_moveTime

 
=

 
$num

 
;

 
private 	
void
 
Start 
( 
) 
{ 
_followCameraData 
= 
GetComponent #
<# $
FollowCameraData$ 4
>4 5
(5 6
)6 7
;7 8
Log 
. 
CheckForNull 
( 
_followCameraData %
,% &

gameObject' 1
,1 2
typeof3 9
(9 :
FollowCameraData: J
)J K
)K L
;L M
} 
private 	
void
 
FixedUpdate 
( 
) 
{ 
var 
anchorPoint 
= 
_followCameraData &
.& '
GetAnchorPoint' 5
(5 6
)6 7
;7 8
var 
	moveSpeed 
= 
_followCameraData $
.$ %
GetMoveSpeed% 1
(1 2
)2 3
;3 4
var 
followObject 
= 
_followCameraData '
.' (
GetFollowObject( 7
(7 8
)8 9
;9 :
if 
( 
anchorPoint 
. 
	transform 
. 
position %
!=& (+
_lastAnchorPointPositionVector3) H
)H I
{ +
_lastAnchorPointPositionVector3 #
=$ %
anchorPoint& 1
.1 2
	transform2 ;
.; <
position< D
;D E
	_moveTime 
= 
$num 
; 
} 
	_moveTime 
+= 
Time 
. 
	deltaTime 
; 
var 
progress 
= 
	_moveTime 
* 
	moveSpeed '
;' (
if 
( 
progress 
> 
$num 
) 
{   
	transform!! 
.!! 
position!! 
=!! +
_lastAnchorPointPositionVector3!! 8
;!!8 9
}"" 
else## 
{$$ 
	transform%% 
.%% 
position%% 
=%% 
Vector3%%  
.%%  !
Lerp%%! %
(%%% &
	transform%%& /
.%%/ 0
position%%0 8
,%%8 9+
_lastAnchorPointPositionVector3%%: Y
,%%Y Z
progress%%[ c
)%%c d
;%%d e
}&& 
var'' 
roteteSpeed'' 
='' 
_followCameraData'' &
.''& '
GetRotateSpeed''' 5
(''5 6
)''6 7
;''7 8
var(( 
rotateProgress(( 
=(( 
roteteSpeed(( #
*(($ %
	_moveTime((& /
;((/ 0
if** 
(** 
followObject** 
!=** 
null** 
)** 
{++ 
LookAt,, 

(,,
 
followObject,, 
.,, 
	transform,, !
.,,! "
position,," *
,,,* +
rotateProgress,,, :
),,: ;
;,,; <
}-- 
}.. 
private00 	
void00
 
LookAt00 
(00 
Vector300 
position00 &
,00& '
float00( -
progress00. 6
)006 7
{11 
var22 
directionVector322 
=22 
position22 "
-22# $
	transform22% .
.22. /
position22/ 7
;227 8
if33 
(33 
directionVector333 
==33 
Vector333 "
.33" #
zero33# '
)33' (
return33) /
;33/ 0
var44 
rotation44 
=44 

Quaternion44 
.44 
LookRotation44 )
(44) *
directionVector344* :
)44: ;
;44; <
var55 
teleportToRotation55 
=55 

Quaternion55 &
.55& '
Slerp55' ,
(55, -
	transform55- 6
.556 7
rotation557 ?
,55? @
rotation55A I
,55I J
progress55K S
)55S T
;55T U
	transform66 
.66 
rotation66 
=66 
teleportToRotation66 *
;66* +
}77 
}88 
}99 ×
RE:\Tanks\Tanks\Assets\Scripts\Game\Renderer\Camera\PlayerFollowCameraController.cs
	namespace 	
Game
 
. 
Renderer 
. 
Camera 
{		 
public

 
class

 (
PlayerFollowCameraController

 *
:

+ ,
MonoBehaviour

- :
{ 
private 	
void
 
Start 
( 
) 
{ 
var 
player 
= 
GameManager 
. 
Instance $
.$ %
GetPlayerGameObject% 8
(8 9
)9 :
;: ;
if 
( 
player 
== 
null 
) 
{ 
Debug 	
.	 

Log
 
( 
$str 
) 
; 
} 
var 
followPoints 
= 
player 
. #
GetComponentsInChildren 4
<4 5

ICameraTag5 ?
>? @
(@ A
)A B
;B C
foreach 

( 
var 
point 
in 
followPoints %
)% &
{ 
if 
( 
point 
is 
PlayerCameraTag  
)  !
{ 
var 
followCameraData	 
= 
GetComponent (
<( )
FollowCameraData) 9
>9 :
(: ;
); <
;< =
Log 
. 	
CheckForNull	 
( 
followCameraData &
,& '

gameObject( 2
,2 3
typeof4 :
(: ;
FollowCameraData; K
)K L
)L M
;M N
followCameraData 
. 
SetAnchorPoint $
($ %
point% *
.* +
GetPoint+ 3
(3 4
)4 5
)5 6
;6 7
} 
} 
} 
} 
} ¾
<E:\Tanks\Tanks\Assets\Scripts\Game\Settings\InputSettings.cs
	namespace 	
Game
 
. 
Settings 
{ 
public 
class 
InputSettings 
{		 
public

 
static

	 
float

 !
ClickMagnitudeMaxSize

 +
=

, -
$num

. 2
;

2 3
public 
static	 
float 
ClickKeepTimeStart (
=) *
$num+ /
;/ 0
public 
static	 
float %
StepInJoystickByBackMoved /
=0 1
-2 3
$num3 7
;7 8
} 
} ö
:E:\Tanks\Tanks\Assets\Scripts\Game\Systems\DamageSystem.cs
	namespace 	
Game
 
. 
Systems 
{ 
public		 
class		 
DamageSystem		 
:		 
MonoBehaviour		 *
{

 
private 	
void
 
Start 
( 
) 
{ 
var 
damageController 
= 
GetComponent &
<& '
IDamageController' 8
>8 9
(9 :
): ;
;; <
if 
( 
damageController 
== 
null 
)  
{ 
Debug 	
.	 

LogError
 
( 
$str )
+* +

gameObject, 6
.6 7
name7 ;
+< =
$str> H
)H I
;I J
} 
else 
{ 
damageController 
. 
SetDamageEvent #
(# $
OnSetDamage$ /
)/ 0
;0 1
} 
} 
public 
void	 
OnSetDamage 
( 

GameObject $
targetGameObject% 5
,5 6
float7 <
damage= C
)C D
{ 
var 
healthSystemWarior 
= 
targetGameObject ,
., -
GetComponent- 9
<9 :
HealthSystem: F
>F G
(G H
)H I
;I J
healthSystemWarior 
? 
. 
	SetDamage  
(  !
damage! '
)' (
;( )
} 
} 
} ™
7E:\Tanks\Tanks\Assets\Scripts\Game\Systems\GunSystem.cs
	namespace 	
Game
 
. 
Systems 
{ 
public 
class 
	GunSystem 
: 
MonoBehaviour '
{		 
private

 	
IGunController


 
_gunController

 '
;

' (
private 	
void
 
Start 
( 
) 
{ 
_gunController 
= 
GetComponent  
<  !
IGunController! /
>/ 0
(0 1
)1 2
;2 3
if 
( 
_gunController 
== 
null 
) 
{ 
Debug 	
.	 

LogError
 
( 
$str &
+' (

gameObject) 3
.3 4
name4 8
+9 :
$str; E
)E F
;F G
} 
} 
private 	
void
 
Update 
( 
) 
{ 
if 
( 
_gunController 
. 
	IsCanFire 
(  
)  !
)! "
{ 
_gunController 
. 
Fire 
( 
) 
; 
} 
} 
} 
} Ó
:E:\Tanks\Tanks\Assets\Scripts\Game\Systems\HealthSystem.cs
	namespace 	
Game
 
. 
Systems 
{ 
public		 
class		 
HealthSystem		 
:		 
MonoBehaviour		 *
{

 
private 	
IHealthController
 $
_currentHealthController 4
;4 5
private 	
Action
 

_deadEvent 
; 
private 	
void
 
Start 
( 
) 
{ $
_currentHealthController 
= 
GetComponent *
<* +
IHealthController+ <
>< =
(= >
)> ?
;? @
if 
( $
_currentHealthController 
==  "
null# '
)' (
{ 
Debug 	
.	 

LogError
 
( 
$str *
+* +

gameObject, 6
.6 7
name7 ;
+< =
$str> G
)G H
;H I
} 
else 
{ 

_deadEvent 
+= 
OnDead 
; $
_currentHealthController 
. 
AddDeadEvent )
() *
ref* -

_deadEvent. 8
)8 9
;9 :
} 
} 
public 
void	 
	SetDamage 
( 
float 
inputDamage )
)) *
{ $
_currentHealthController 
. 
	SetDamage %
(% &
inputDamage& 1
)1 2
;2 3
if 
( $
_currentHealthController 
.  
IsDead  &
(& '
)' (
)( )
{ 

_deadEvent   
?   
.   
Invoke   
(   
)   
;   
}!! 
}"" 
private$$ 	
void$$
 
OnDead$$ 
($$ 
)$$ 
{%% 
Destroy&& 

(&&
 

gameObject&& 
)&& 
;&& 
}'' 
public)) 
void))	 
AddDeadEvent)) 
()) 
Action)) !
newDeadEvent))" .
))). /
{** 

_deadEvent++ 
+=++ 
newDeadEvent++ 
;++ 
},, 
}-- 
}.. Ù#
8E:\Tanks\Tanks\Assets\Scripts\Game\Systems\MoveSystem.cs
	namespace 	
Game
 
. 
Systems 
{ 
public 
class 

MoveSystem 
: 
MonoBehaviour (
{		 
	protected

 
IMoveController

 
UnitsMoveController

 /
;

/ 0
private 	
Rigidbody2D
 
_unitsRigidbody2D '
;' (
	protected 
MoveData 
UnitsMoveData "
;" #
	protected 
void &
InitialBaseMoveSystemField +
(+ ,
), -
{ 
UnitsMoveController 
= 
GetComponent %
<% &
IMoveController& 5
>5 6
(6 7
)7 8
;8 9
UnitsMoveData 
= 
GetComponent 
<  
MoveData  (
>( )
() *
)* +
;+ ,
Log 
. 
CheckForNull 
( 
UnitsMoveController '
,' (

gameObject) 3
,3 4
typeof5 ;
(; <
IMoveController< K
)K L
)L M
;M N
Log 
. 
CheckForNull 
( 
UnitsMoveData !
,! "

gameObject# -
,- .
typeof/ 5
(5 6
MoveData6 >
)> ?
)? @
;@ A
} 
private 	
void
 
Start 
( 
) 
{ &
InitialBaseMoveSystemField 
( 
) 
;  
_unitsRigidbody2D 
= 
GetComponent #
<# $
Rigidbody2D$ /
>/ 0
(0 1
)1 2
;2 3
Log 
. 
CheckForNull 
( 
_unitsRigidbody2D %
,% &

gameObject' 1
,1 2
typeof3 9
(9 :
Rigidbody2D: E
)E F
)F G
;G H
} 
private 	
void
 
FixedUpdate 
( 
) 
{ 
UpdateTransform   
(   
)   
;   
}!! 
	protected## 
virtual## 
void## 
UpdateTransform## (
(##( )
)##) *
{$$ 
UnitsMoveController%% 
.%% 
CulculateTarget%% &
(%%& '
)%%' (
;%%( )
if'' 
('' 
!'' 
UnitsMoveData'' 
.'' 
GetIsOnlyRotete'' %
(''% &
)''& '
)''' (
{(( 
var)) 
forwardVector3)) 
=)) 
UnitsMoveData)) &
.))& '&
GetForwardDirectionVector3))' A
())A B
	transform))B K
)))K L
;))L M
var** 
position** 
=** 
UnitsMoveController** &
.**& '"
GetNextPosirionVector3**' =
(**= >
forwardVector3**> L
)**L M
;**M N
Move,, 
(,, 	
position,,	 
),, 
;,, 
}-- 
var// "
normalDirectionVector3// 
=// 
UnitsMoveData//  -
.//- .%
GetNormalDirectionVector3//. G
(//G H
)//H I
;//I J
var00 
rotation00 
=00 
UnitsMoveController00 %
.00% &%
GetNextRotationQuaternion00& ?
(00? @"
normalDirectionVector300@ V
)00V W
;00W X
Rotate22 	
(22	 

rotation22
 
)22 
;22 
}33 
	protected55 
virtual55 
void55 
Move55 
(55 
Vector355 %
newPositionVector355& 8
)558 9
{66 
_unitsRigidbody2D77 
?77 
.77 
MovePosition77 "
(77" #
newPositionVector377# 5
)775 6
;776 7
}88 
	protected:: 
virtual:: 
void:: 
Rotate:: 
(::  

Quaternion::  *
rotationQuaternion::+ =
)::= >
{;; 
	transform<< 
.<< 
rotation<< 
=<< 
rotationQuaternion<< *
;<<* +
}== 
}>> 
}?? “
8E:\Tanks\Tanks\Assets\Scripts\Game\Systems\TeamSystem.cs
	namespace 	
Game
 
. 
Systems 
{		 
public

 
class

 

TeamSystem

 
:

 
MonoBehaviour

 (
{ 
private 	
TeamData
 
	_teamData 
; 
private 	
ITeamController
 
_teamController )
;) *
private 	
void
 
Awake 
( 
) 
{ 
	_teamData 
= 
GetComponent 
< 
TeamData $
>$ %
(% &
)& '
;' (
_teamController 
= 
GetComponent !
<! "
ITeamController" 1
>1 2
(2 3
)3 4
;4 5
Log 
. 
CheckForNull 
( 
	_teamData 
, 

gameObject )
,) *
typeof+ 1
(1 2
TeamData2 :
): ;
); <
;< =
Log 
. 
CheckForNull 
( 
_teamController #
,# $

gameObject% /
,/ 0
typeof1 7
(7 8
ITeamController8 G
)G H
)H I
;I J
_teamController 
. 
InitialAction  
(  !
)! "
;" #
} 
} 
} 