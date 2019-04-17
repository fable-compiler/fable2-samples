// samples taken from: https://developer.mozilla.org/fr/docs/Tutoriel_canvas/Formes_g%C3%A9om%C3%A9triques

export function drawSmiley( id ) {
  let canvas = document.getElementById(id);
  if (canvas.getContext) {
    let ctx = canvas.getContext('2d');

    ctx.beginPath();
    ctx.arc(75, 75, 50, 0, Math.PI * 2, true);  // Cercle extérieur
    ctx.moveTo(110,75);
    ctx.arc(75, 75, 35, 0, Math.PI, false);  // Bouche (sens horaire)
    ctx.moveTo(65, 65);
    ctx.arc(60, 65, 5, 0, Math.PI * 2, true);  // Oeil gauche
    ctx.moveTo(95, 65);
    ctx.arc(90, 65, 5, 0, Math.PI * 2, true);  // Oeil droite
    ctx.stroke();
  }  
}

export function drawBubble( id ) {
  let canevas = document.getElementById(id);
  if (canevas.getContext) {
    let ctx = canevas.getContext('2d');

    ctx.beginPath();
    ctx.moveTo(75, 25);
    ctx.quadraticCurveTo(25, 25, 25, 62.5);
    ctx.quadraticCurveTo(25, 100, 50, 100);
    ctx.quadraticCurveTo(50, 120, 30, 125);
    ctx.quadraticCurveTo(60, 120, 65, 100);
    ctx.quadraticCurveTo(125, 100, 125, 62.5);
    ctx.quadraticCurveTo(125, 25, 75, 25);
    ctx.stroke();
  }
}