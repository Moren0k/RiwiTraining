class Celular {
    constructor(color, peso, rdp, rdc, ram){
        this.color = color;
        this.peso = peso;
        this.rdp = rdp;
        this.rdc = rdc;
        this.ram = ram;

        this.power = false;
    }
    botonPower(){
        if (this.power == false) {
            console.log("El celular se prendio");
            this.power = true;
        } else {
            console.log("Celular apagado");
            this.power = false;
        }
    }

    reiniciar(){
        if (this.power == true) {
            console.log("El celular se reinició");
        } else {
            console.log("El celular está apagado");
        }
    }

    tomarFoto(){
        if (this.power == true) {
            console.log(`Foto tomada con una resolución de ${this.rdp} megapíxeles`);
        } else {
            console.log("El celular está apagado, no se puede tomar la foto");
        }
    }

    grabarVideo(){
        if (this.powe == true) {
            console.log(`Grabando video con una resolución de ${this.rdc} megapíxeles`);
        } else {
            console.log("El celular está apagado, no se puede grabar el video");
        }
    }
    infoCelular(){
        return `Celular de color ${this.color}, peso ${this.peso} gramos, resolución de pantalla ${this.rdp} megapíxeles, resolución de cámara ${this.rdc} megapíxeles y RAM de ${this.ram} GB.`;
    }
}

let celular1 = new Celular("Negro", "150", "1080p", "12", "8");
let celular2 = new Celular("Blanco", "160", "720p", "8", "4");
let celular3 = new Celular("Rojo", "140", "1440p", "16", "6");
