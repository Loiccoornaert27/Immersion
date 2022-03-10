import { Diplome } from "./Diplome";
import { HardSkill } from "./HardSkill";
import { SoftSkill } from "./SoftSkill";

export interface Poste{
    id: number;
    intitule: string;
    description: string;
    categorie: string;
    diplomes: Diplome[];
    softSkills: SoftSkill[];
    hardSkills: HardSkill[];
}