# E4FI 1I S2 2k24/25 - Projet - EDMEE Léon & DELMAS Denis

Class : 1I - E4FI - 2025 - ESIEE Paris
Students : EDMEE Léon (leon.edmee@edu.esiee.fr)
                   DELMAS Denis (delmas.denis@edu.esiee.fr)

Classification PEGI : 

- Les missiles et les bruits d’explosion peuvent effrayer les jeunes enfants
- De plus la musique angoissante peut les stresser
- Le jeu ne présente pas de violence explicite (insultes, armes, sang) ou de transactions en ligne.

![Untitled.png](imgs/Untitled.png)

Source : [https://pegi.info/fr/page/que-signifient-les-logos](https://pegi.info/fr/page/que-signifient-les-logos)

## Vidéos de présentation

*Afin que les vidéos en durent pas trop longtemps nous avons limité la condition de victoire à la mort de 2 vaisseaux ennemis.*

### Vidéo complète

[https://drive.google.com/file/d/1Yei91C3qhDaPECs6Md7BTHclZbS0qGNT/view?usp=sharing](https://drive.google.com/file/d/1Yei91C3qhDaPECs6Md7BTHclZbS0qGNT/view?usp=sharing) - Google Drive

## Code source

[https://github.com/Leon-ED/unity_project](https://github.com/Leon-ED/unity_project) - Github

## Cahier des Charges

[https://miro.com/app/board/uXjVI0wuucg=/?share_link_id=290241123065](https://miro.com/app/board/uXjVI0wuucg=/?share_link_id=290241123065) - Miro

# Sources

Aucun asset payant n’a été utilisé, voici la liste de ceux utilisés :

Unity Store: [https://assetstore.unity.com/](https://assetstore.unity.com/)

Poly haven : [https://polyhaven.com/](https://polyhaven.com/)

Texture Sol : [https://polyhaven.com/a/rocky_trail_02](https://polyhaven.com/a/rocky_trail_02)

Particules : [https://assetstore.unity.com/packages/vfx/particles/sherbb-s-particle-collection-170798](https://assetstore.unity.com/packages/vfx/particles/sherbb-s-particle-collection-170798)

Skybox : [https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-series-free-103633](https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-series-free-103633)

Vaisseau: [https://assetstore.unity.com/packages/3d/vehicles/space/space-warrior-jet-23174](https://assetstore.unity.com/packages/3d/vehicles/space/space-warrior-jet-23174)

Musique de fond: [https://www.youtube.com/watch?list=PLPfHaI9XqTnFzvCP_YHvVE6l8al2gdzvB&v=5kgxj-bnPfk&feature=youtu.be](https://www.youtube.com/watch?list=PLPfHaI9XqTnFzvCP_YHvVE6l8al2gdzvB&v=5kgxj-bnPfk&feature=youtu.be)

Bruit d’explosion : [https://www.youtube.com/watch?v=bMymzwvJcSk](https://www.youtube.com/watch?v=bMymzwvJcSk)

Bruit de téléportation/victoire : [https://www.youtube.com/watch?v=D0HDWQomaWc](https://www.youtube.com/watch?v=D0HDWQomaWc)

### Aide pour le développement

[https://stackoverflow.com/](https://stackoverflow.com/) - Stack Overflow

[https://github.com/features/copilot](https://github.com/features/copilot) - Github Copilot

# Fonctionnement

*Il faut tuer les vaisseaux ennemis qui brouillent notre téléporteur.*

*Les vaisseaux ennemis sont arrêtés grâce à notre bouclier cinétique qui les empêche de bouger.*

Le jeu est prévu pour fonctionner sur une manette.

Il faut tuer les vaisseaux ennemis sans toucher le sol sinon c’est la fin du jeu.

Lorsque tous les vaisseaux sont tués, la partie est finie et le vaisseau s’arrête, car le signal de notre téléporteur est rétabli, nous allons pouvoir retourner au vaisseau mère de la flotte de l’ASN.

# Théorie des I²

## 1. Immersion

- **Échelle et environnement** : Jouer avec la notion de taille — notre vaisseau est minuscule à côté de ces géants. Ça crée une sensation d’émerveillement, de danger et d’infini.
- **Audio spatial 3D** :Sons des explosions, tirs qui résonnent, avec un effet de distance réaliste.
- **Effets visuels** : Particules, fumée, traînées de propulsion, effets de distorsion pour la vitesse ou les impacts.
- **Camera immersive** : Caméra à la première personne avec mouvements fluides.

## 2. Interactivité :

- **Contrôle du vaisseau** : Mouvement libre en 3D (translation + rotation), avec un ressenti de poids, inertie (physique), accélération.
- **Armes et défense** : Tirer sur les envahisseurs de façon interactive.
- **Interactions avec l’environnement** : Utiliser l’espace entre les ennemis, se cacher derrière le décors.

# Les courants philosophiques & Lore du jeu
## 0. **La décolonisation et l'anticolonialisme**

Notre espèce s’est toujours targuée d’être la plus puissante que la Terre ait portée. Depuis l’aube de son histoire, l’humanité n’a eu de cesse de chasser, d’exploiter et de tuer les autres formes de vie, qu’il s’agisse d’animaux chassés pour se nourrir, d’écosystèmes ravagés au nom du progrès, – plus insidieusement – d’autres communautés humaines réduites en esclavage et soumises pour le seul profit du confort ou de l’enrichissement, mais aussi d'attentats pour des différences idéologiques ou de violentes guerres meutrières. Des millions de vies humaines ont été perdues... Des espèces entières, présentes sur la planète depuis des millénaires, ont été anéanties ; des peuples entiers ont subi la violence d’une prétendue « civilisation » qui justifiait l’oppression par un sentiment de supériorité.

Pourtant, en 2027, lorsque la Terre est assiégée par une force extraterrestre venue d’au-delà de nos étoiles, le miroir se brise. L’humanité découvre qu’elle n’est ni la seule, ni la plus forte, ni la plus ingénieuse des races de l’univers. Pendant des millénaires, elle a régné sur ses semblables et sur son environnement, écrasant toute forme de vie jugée inférieure. Et voilà qu’elle se trouve, du jour au lendemain, contrainte de se battre pour sa survie contre un adversaire dépassant largement ses capacités technologiques et cognitives.

Cet « arroseur » qui, à force de tyranniser et d’asservir, se croyait à l’abri de toute riposte, subit à présent le « retour de bâton ». Ce renversement de situation n’est pas seulement un ressort de science-fiction ; c’est une fable presque divine de justice immanente : la force qui a opprimé est elle-même opprimée, l’espèce qui a réduit d’autres peuples à l’esclavage risque d’être, à son tour, réduite à l’impuissance et à la servitude.

Face à l’invasion, l’humanité doit enfin mesurer l’ampleur de son hypocrisie et de sa violence historique. Elle doit prendre conscience qu’aucune supériorité n’est inaliénable et que chaque acte de domination porte en germe son propre retournement. Comme les peuples colonisés d’hier ont résisté et reconquis leur liberté, comme tant d’animaux et d’écosystèmes ont lutté pour subsister, l’humanité doit aujourd’hui, elle aussi, se dresser, unir ses forces et repenser son rapport à l’autre – qu’il soit humain ou extraterrestre, animal ou végétal.

En définitive, cette épreuve planétaire pourrait devenir le prélude d’une véritable décolonisation universelle : non seulement la fin de la colonisation de la nature et des peuples entre eux, mais aussi l’émergence d’une conscience collective capable de reconnaître la valeur intrinsèque de chaque être, la fragilité du pouvoir et l’impératif moral de la réciprocité. C’est peut-être l’ultime leçon que l’univers nous offre : si l’on veut éviter la disparition, il faut apprendre à ne plus réduire ses semblables – quels qu’ils soient – à l’état d’objets, et reconsidérer la force comme la responsabilité de protéger plutôt que d’asservir.

L'espèce humaine retiendra-elle la leçon ? Où est-ce qu'elle continuera à ignorer les rappels de Dieu.
## 1. **L’écosophie**

Les missions explorent les conséquences de la rupture de l’équilibre naturel, ou la nécessité d’inclure les systèmes écologiques dans les décisions tactiques (protéger un biome sacré, restaurer un monde mourant…).

## 2. **Le stoïcisme**

NIDAL est tiraillé entre son destin tragique et sa capacité à incarner la vertu dans un monde corrompu. L’idée de « faire le bien, même quand tout s’effondre » renforce la tension dramatique du personnage.

## 3. **Le vitalisme**

Face à l’ordre technocratique et impérial, la résistance incarne un souffle vitaliste : intuitif, organique, parfois mystique. Le contraste entre la machine froide et les peuples vivants serait accentué.

## 4. **L’absurde**

Notre héros NIDAL incarne cette tension : lutter sans garantie de victoire, par devoir, simplement pour refuser l’inhumanité du monde. Cela donne un sous-texte profond à chaque mission : la dignité d’agir, même dans un monde absurde.

## 6. **Le transhumanisme / posthumanisme critique**

NIDAL est une figure post-humaine par essence. Le jeu questionne la frontière entre nature, culture, machine et mythe. Le joueur apprendrait à penser au-delà de l’humain.

## 7. **L’anarchisme**

L’alliance résistante fonctionne sans leader central, selon des principes autogérés. Des tensions pourraient naître entre ceux qui veulent un commandement fort et ceux qui prônent l’horizontalité. Certaines missions pourraient imposer au joueur de choisir entre efficacité hiérarchique et respect des principes libertaires.

# BackStory

Notre jeu est basé dans l’espace. 

Suite à la guerre des planètes de 2027 que la Terre ainsi que l’espèce humaine a perdue. ASN (Agence Spatiale Noiséenne) est une organisation qui lutte contre l’invasion extra-terrestre. Elle comporte plusieurs millions de membres dans la galaxy et elle est dirigée par un certain Duster. Leur vaisseau mère est souvent appelé FF500 en référence à sa couleur dorée.

Le héros que vous incarnez est le lieutenant colonel divisionnaire maréchal des logis chef NIDAL. Après avoir combattu dans la 3ème division blindée de l’OTAN lors de la guerre de 2027, vous avez été blessé grièvement au combat. Des luniens (espèce vivant sur la Lune) vous ont secouru et soigné grâce à leur technologie très avancée. Vous aviez perdu l’usage des jambes et de vos yeux mais vous êtes maintenant un mi homme, mi cyborg, mi cheval.

`“Alors que les vaisseaux Mirandas se rapprochent inexorablement, le lieutenant colonel NIDAL coordonne les efforts de son équipage avec une précision chirurgicale. Les systèmes de défense du FF500 s'activent, libérant un déluge de tirs de suppression pour ralentir l'avancée ennemie.`

`Les Mirandas, redoutables dans leur technologie et leur nombre, ne reculent pas devant l'assaut initial. Leurs vaisseaux, élégamment conçus mais redoutablement armés, lancent des salves de projectiles énergétiques, ébranlant les boucliers du FF500. Les membres de l'équipage se battent avec férocité, faisant preuve d'un courage indomptable face à l'adversité.`

`Le lieutenant colonel NIDAL, monté sur son destrier cybernétique, mène l'assaut contre les vaisseaux ennemis avec une détermination sans faille. Malgré ses blessures passées, il est un véritable symbole de résilience et d'espoir pour son équipage. Ses sens augmentés lui permettent de percevoir le moindre mouvement ennemi, lui donnant un avantage stratégique crucial dans la bataille.`

`Alors que le combat fait rage dans l'espace infini, le FF500 et son équipage se battent avec une bravoure légendaire. Les éclats d'énergie illuminent l'obscurité de l'espace, créant un ballet mortel entre les vaisseaux ennemis et les défenseurs de l'humanité. Chaque membre de l'équipage sait qu'il joue un rôle essentiel dans la défense de leur planète contre les Mirandas impitoyables.`

`Dans ce moment critique, le destin d'Azure AD repose entre les mains du lieutenant colonel NIDAL et de son équipage dévoué. Ils sont prêts à tout sacrifier pour assurer la survie de leur foyer et repousser l'invasion extra-terrestre.” - Journal de Bord du vaisseau mère` 

L'humanité, dans son insatiable quête de conquête, a toujours vu l'univers comme une ressource à exploiter. Après avoir ravagé la Terre par des siècles de pollution et de guerres, les humains se sont tournés vers les étoiles, emportant avec eux leur insatiable appétit destructeur.

En 2027, la **Grande Guerre Interplanétaire** éclata lorsque les nations terrestres lancèrent des offensives coordonnées contre les civilisations établies sur les planètes voisines. Les humains, géants, avec leur technologie brute et leur mépris des équilibres naturels, détruisirent des écosystèmes entiers pour s'approprier les richesses des astres. Mais cette fois, leurs ambitions les conduisirent à une résistance farouche.

Les planètes unies repoussèrent l’invasion, et la Terre, écrasée par ses propres excès et ses pertes militaires, fut abandonnée. Pourtant, les humains survivants, galvanisés par leur instinct de domination, revinrent plus puissants, menés par une alliance militarisée appelée **H.O.R.D.E.** (*Human Offensive for Resource Domination and Expansion*).

Ces nouveaux envahisseurs pillent, détruisent, et polluent sans pitié, éradiquant tout ce qui ne leur est pas utile. L’univers tout entier est maintenant menacé par cette machine de guerre insatiable.

## L’ASN : La Résistance Galactique

Face à la H.O.R.D.E., des survivants de civilisations colonisées se sont unis pour protéger leurs mondes. Ils ont formé l’**ASN (Agence Spatiale Noiséenne)**, une organisation de résistants qui lutte contre l’invasion humaine.

L’ASN regroupe des êtres de toutes origines, qu’ils soient natifs des colonies ou anciens dissidents humains. Leur quartier général est basé à bord du **FF500**, un gigantesque vaisseau doré conçu comme un symbole d’espoir pour les opprimés. Sous le commandement du légendaire **Duster**, l’ASN mène une guerre désespérée pour sauver ce qui reste de l’univers.

## Le Héros : Lieutenant-Colonel NIDAL

Vous incarnez le **Lieutenant-Colonel NIDAL**, un ancien officier de l’armée terrestre, trahi par ses propres supérieurs après avoir refusé de participer à des massacres de civils sur des colonies. Gravement blessé lors de sa désertion, vous fûtes recueilli et soigné par les **Luniens**, une civilisation avancée vivant sur la Lune, connue pour ses prouesses médicales.

Grâce à leur technologie, vous avez été reconstruit :

- Vos jambes perdues ont été remplacées par des prothèses cybernétiques puissantes.
- Vos yeux, désormais augmentés, voient au-delà des spectres humains.
- Et en hommage à leur histoire, les Luniens vous ont offert un **destrier cybernétique**, une fusion de machine et de créature vivante, symbole de leur résistance.

Bien que transformé, vous êtes devenu une figure clé de l’ASN, un héros galvanisant les opprimés, tout en portant le fardeau des atrocités commises par votre propre espèce.

## L’Ultime Combat Contre la H.O.R.D.E.

Le conflit s’intensifie alors que les flottes humaines avancent dans la galaxie, consumant des planètes entières sur leur passage.

À bord du **FF500**, vous dirigez les forces de l’ASN pour contrer l’inexorable progression de la H.O.R.D.E. Le combat est inégal. Les humains, armés jusqu’aux dents, disposent d’une technologie dévastatrice, mais leur plus grande faiblesse reste leur aveuglement : leur mépris pour la vie et leur incapacité à travailler avec la nature les rendent vulnérables.

### Vos missions :

- Saboter leurs usines flottantes qui contaminent la Terre.
- Protéger les dernières planètes intactes de l’univers.
- Convaincre d’autres colonies de rejoindre la résistance.

Alors que les batailles font rage dans l’espace infini, chaque victoire est une étincelle d’espoir pour l’ASN et une défaite humiliante pour l’envahisseur.

Mais la H.O.R.D.E. n’abandonnera pas facilement. Les flottes humaines, dirigées par des généraux impitoyables, ne reculeront devant rien pour écraser la résistance.

## Un Combat pour la Survie

Face à la H.O.R.D.E., vous êtes le dernier rempart. Vos choix détermineront le sort de la galaxie :

- **La résistance triomphera-t-elle ?**
- **Ou l’humanité dévorera-t-elle tout sur son passage, laissant derrière elle un univers mort et stérile ?**

> “Nous combattons non pas pour nous-mêmes, mais pour l’avenir. Si nous tombons, l’univers tout entier disparaîtra sous la marée humaine.”
> 
> 
> – Journal de Bord du FF500
> 

# Extraits de code

Gestion du mouvement en VR

![Code 1.png](imgs/Code%201.png)

La manette de droite permet de déplacer le vaisseau en maintenant le “grab” lorsqu’on est sur le manche du vaisseau. En appuyant sur la gâchette arrière, on active le boost du vaisseau.

Gestion du missile, on peut tirer un missile avec le bouton A de la manette

![Code 2.png](imgs/Code%202.png)

On regarde les colissions avec les ennemis

![Code 3.png](imgs/Code%203.png)

On ajoute un retour haptique pour le joueur afin d’améliorer l’immertion

![Code 4.png](imgs/Code%204.png)
