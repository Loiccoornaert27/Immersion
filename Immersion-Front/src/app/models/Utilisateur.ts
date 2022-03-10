import { Diplome } from "./Diplome";
import { HardSkill } from "./HardSkill";
import { SoftSkill } from "./SoftSkill";

export interface Utilisateur{
    id : number;
    nom : string;
    prenom : string;
    hardSkills: HardSkill[];
    softSkills: SoftSkill[];
    diplomes : Diplome[];
    
}