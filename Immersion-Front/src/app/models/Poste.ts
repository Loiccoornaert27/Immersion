import { Diplome } from "./Diplome";
import { HardSkill } from "./HardSkill";
import { SoftSkill } from "./SoftSkill";

export interface Poste{
    id: number;
    name: string;
    description: string;
    category: string;
    diplomes: Diplome[] | null;
    softSkills: SoftSkill[] | null;
    hardSkills: HardSkill[] | null;
}