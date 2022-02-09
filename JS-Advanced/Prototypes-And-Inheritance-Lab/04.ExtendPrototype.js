function extendProrotype(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function toSpeciesString(){
        return `I am a ${this.species}. ${this.toString()}`;
    }
}