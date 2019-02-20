using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorProMLG
{
    public class CompiAAlgorithms
    {
        /********/
        bool Error = false;
        public Dictionary<string, List<string>> DiccioAnalizador = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> DiccioPrimeros = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> DiccioSiguiente = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> DiccioAux = new Dictionary<string, List<string>>();
        /********/
        public List<List<string>> Aumentada = new List<List<string>>();
        public List<string> sg = new List<string>();
        public List<List<ElementoLr1>> C = new List<List<ElementoLr1>>();
        public Dictionary<string, Dictionary<int, int>> TablaDeEstados = new Dictionary<string, Dictionary<int, int>>();
        /*********/
        public Dictionary<int, Dictionary<string, string>> Accion = new Dictionary<int, Dictionary<string, string>>();
        public Dictionary<string, List<string>> DiccioLR1 = new Dictionary<string, List<string>>();

        public CompiAAlgorithms()
        {
            //TODO?
        }

        public void UpdateAnalizador(string input)
        {
            DiccioAnalizador.Clear();
            bool antesFlecha;
            string[] divInput = input.Split('\n');
            Error = false;
            //recorre los renglones
            foreach (string iterator in divInput)
            {
                antesFlecha = true;
                string it = iterator.Trim();
                string NoTer = "";
                string SiTer = "";
                //recorre la cadena de el renglon
                for (int i = 0; i < it.Length; i++)
                {
                    if (!Error)
                    {
                        if (antesFlecha)
                        {
                            switch (it[i])
                            {
                                case '-':
                                    if (i >= it.Count() - 1)
                                        Error = true;
                                    else
                                    {
                                        if (it[i + 1] == '>')
                                        {
                                            antesFlecha = false;
                                            i++;
                                            if (NoTer.Count() <= 0)
                                                GenerarError(" faltan elementos antes de la flecha");
                                            else
                                            {
                                                //checa si es tipo 2 con epsilon o sino da error
                                                if ((NoTer.Count() == 1 && !Char.IsUpper(char.Parse(NoTer))) || NoTer.Count() > 1 || NoTer.Contains("Ɛ"))
                                                    GenerarError(" la entrada no es Tipo 2 (Libre de Contexto).");
                                            }
                                        }
                                    }
                                    break;
                                case ' ':
                                    break;
                                default:
                                    NoTer += it[i].ToString();
                                    break;
                            }
                        }
                        else
                        {
                            switch (it[i])
                            {
                                case '|':
                                    if (SiTer.Count() <= 0 || i >= it.Count() - 1)
                                        GenerarError(" faltan elementos antes de la union");
                                    else
                                    {
                                        if (!DiccioAnalizador.Keys.Contains(NoTer))
                                            DiccioAnalizador.Add(NoTer, new List<string>());
                                        DiccioAnalizador[NoTer].Add(SiTer);
                                    }
                                    SiTer = "";
                                    break;
                                case ' ':
                                    break;
                                default:
                                    SiTer += it[i].ToString();
                                    if (i >= it.Count() - 1)
                                    {
                                        if (SiTer.Count() <= 0)
                                            GenerarError(" faltan elementos despues de la flecha");
                                        else
                                        {
                                            if (!DiccioAnalizador.Keys.Contains(NoTer))
                                                DiccioAnalizador.Add(NoTer, new List<string>());
                                            DiccioAnalizador[NoTer].Add(SiTer);
                                        }
                                        SiTer = "";
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void GenerarError(string texto)
        {
            Error = true;
            DiccioAnalizador.Clear();
            DiccioAnalizador.Add("Error ", new List<string>());
            DiccioAnalizador["Error "].Add(texto);
        }

        public void UpdatePrimero()
        {
            DiccioPrimeros.Clear();
            DiccioAux.Clear();
            /*Generar Primero*/
            if (!Error && DiccioAnalizador.Count > 0)
                foreach (string itK in DiccioAnalizador.Keys.ToList())
                    PrimNoT(itK);
            for (int x = 0; x < DiccioAux.Count; x++)
            {
                DiccioPrimeros.Add(DiccioAux.Keys.ToList()[x], DiccioAux[DiccioAux.Keys.ToList()[x]]);
            }
        }

        private List<string> PrimNoT(string keyname)
        {
            List<int> indx = new List<int>();
            int counter = 0;
            List<string> result = new List<string>();
            if (!DiccioPrimeros.ContainsKey(keyname))
            {
                //Recorre las producciones del NT
                foreach (string itV in DiccioAnalizador[keyname])
                {
                    if (itV[0].ToString() == keyname)
                    {
                        indx.Add(counter);
                    }
                    else
                    {
                        //Agrega los datos en el resultado
                        List<string> PrimOutput = Primero(itV, keyname);
                        foreach (string it in PrimOutput)
                            if (!result.Contains(it))
                                result.Add(it);
                    }
                    counter++;
                }
                DiccioPrimeros.Add(keyname, result);
                foreach (int itdx in indx)
                {
                    if (DiccioPrimeros[keyname].Contains("Ɛ"))
                    {   //Agrega los datos en el resultado
                        List<string> PrimOutput = Primero(DiccioAnalizador[keyname][itdx], keyname);
                        foreach (string it in PrimOutput)
                            if (!result.Contains(it))
                                result.Insert(itdx, it);
                    }
                }
            }
            return result;
        }

        private List<string> Primero(string produccion, string key)
        {
            int k = 0;
            bool continuar = true;
            List<string> result = new List<string>();
            while (continuar && k < produccion.Length) //Recorre X_1 ,X_2 ... ,X_k.
            {
                string Xk = produccion[k].ToString();
                if (!Char.IsUpper(produccion[k]) || produccion[k] == 'Ɛ')
                {
                    //es Term o Epsilon
                    if (Xk != "Ɛ")
                    {
                        if (!result.Contains(Xk))
                            result.Add(Xk);
                        continuar = false;
                    }
                    //Agregar Terminales primeros
                    if (!DiccioAux.Keys.Contains(Xk))
                    {
                        List<string> InputList = new List<string> { Xk };
                        DiccioAux.Add(Xk, new List<string>(InputList));
                    }

                }
                else
                {
                    //es No-Term
                    List<string> auxL = new List<string>();
                    bool EpCheck = false;

                    if (Xk != key)
                    {
                        PrimNoT(Xk);
                        auxL = new List<string>(DiccioPrimeros[Xk]);
                        if (auxL.Contains("Ɛ"))
                        {
                            EpCheck = true;
                            auxL.Remove("Ɛ");
                        }
                        foreach (string itP in auxL)
                        {
                            if (!result.Contains(itP))
                                result.Add(itP);
                        }

                        if (!EpCheck)
                            continuar = false;
                    }
                }
                k++;
            }
            if (continuar)
                result.Add("Ɛ");
            return result;
        }

        public void UpdateSiguiente()
        {
            DiccioSiguiente.Clear();
            DiccioAux.Clear();
            //inicializa el diccionario de siguientes
            for (int i = 0; i < DiccioAnalizador.Count; i++)
            {
                List<string> inptLstr = new List<string>();
                if (i == 0)
                    inptLstr.Add("$");
                DiccioAux.Add(DiccioAnalizador.Keys.ToList()[i], new List<string>());
                DiccioSiguiente.Add(DiccioAnalizador.Keys.ToList()[i], inptLstr);
            }
            for (int i = 0; i < DiccioAnalizador.Count; i++)
            {
                string key = DiccioAnalizador.Keys.ToList()[i];
                List<string> ListaDeProds = new List<string>(DiccioAnalizador[key]);
                for (int j = 0; j < ListaDeProds.Count; j++)
                {   //reccorre todas las producciones de una key
                    string produccion = ListaDeProds[j];
                    for (int k = 0; k < produccion.Count(); k++)
                    {   //recorre cada elemento de la produccion
                        if (char.IsUpper(produccion[k]) && produccion[k] != 'Ɛ')
                        {   //es Xk  es no-terminal
                            string Xk = produccion[k].ToString();
                            string StrInput = "";
                            for (int l = k + 1; l < produccion.Count(); l++)
                                StrInput += produccion[l];
                            if (StrInput == "")
                                StrInput = "Ɛ";
                            List<string> PrimInput = Primero(StrInput, "");
                            int indexEp = PrimInput.FindIndex(ep => ep == "Ɛ");
                            if (indexEp >= 0)
                                PrimInput.RemoveAt(indexEp);
                            bool cambiado = false;
                            foreach (string it in PrimInput)
                                if (!DiccioSiguiente[Xk].Contains(it))
                                {
                                    cambiado = true;
                                    DiccioSiguiente[Xk].Add(it);
                                }
                            if (cambiado)
                                UpdateRelsSig(Xk);
                            if (indexEp >= 0)
                                if (Xk != key && !DiccioAux[key].Contains(Xk))
                                {
                                    DiccioAux[key].Add(Xk);
                                    UpdateRelsSig(key);
                                }
                        }
                    }
                }
            }
        }

        private void UpdateRelsSig(string keyChanged)
        {
            List<string> KeySaver = new List<string>();
            foreach (string relation in DiccioAux[keyChanged])
            {
                bool cambio = false;
                foreach (string RelToAdd in DiccioSiguiente[keyChanged])
                    if (!DiccioSiguiente[relation].Contains(RelToAdd))
                    {
                        cambio = true;
                        DiccioSiguiente[relation].Add(RelToAdd);
                    }
                if (cambio)
                    KeySaver.Add(relation);
            }
            foreach (string Key in KeySaver)
                UpdateRelsSig(Key);
        }

        public void UpdateLr1Automata()
        {
            sg = GeneraSimbGram();
            GeneraAumentada();
            foreach (string str in sg)
                TablaDeEstados.Add(str, new Dictionary<int, int>());
            C = GeneraAutomata();

            for (int i = 0; i < C.Count; i++)
                foreach (string str in sg)
                {   //Det. si existe algo en T.Edos[sg][origen]
                    bool existe = TablaDeEstados[str].Any(query => query.Key == i);
                    if (!existe)
                        TablaDeEstados[str].Add(i, -1);
                }
        }

        private List<List<ElementoLr1>> GeneraAutomata()
        {
            C = new List<List<ElementoLr1>>();
            List<ElementoLr1> primElemento = new List<ElementoLr1>
                    { new ElementoLr1(Aumentada[0][0], "."+ Aumentada[0][1], '$') };
            primElemento = Cerradura(primElemento);
            C.Add(primElemento);

            for (int i = 0; i < C.Count; i++)
            {
                for (int j = 0; j < sg.Count; j++)
                {
                    List<ElementoLr1> NextElemento = Ir_A(C[i], sg[j]);

                    int different = C.FindIndex(query => CheckDifferentState(query, NextElemento) == false);

                    if (NextElemento.Count > 0)
                    {
                        if (different == -1)
                        {
                            C.Add(NextElemento);
                            //Se hace relacion
                            TablaDeEstados[sg[j]].Add(i, C.Count - 1);
                        }
                        else
                        {
                            //Se hace relacion
                            TablaDeEstados[sg[j]].Add(i, different);
                        }
                    }
                }
            }
            return C;
        }

        private List<ElementoLr1> Ir_A(List<ElementoLr1> I, string X)
        {
            List<ElementoLr1> J = new List<ElementoLr1>();
            foreach (ElementoLr1 elemLr1 in I)
            {
                int dotLocation = elemLr1.GetDotLocation();
                if (dotLocation != -1)
                {
                    string B = elemLr1.value[dotLocation + 1].ToString();
                    if (B == X)
                    {
                        string modValue = elemLr1.value;
                        modValue = modValue.Remove(dotLocation, 1);
                        modValue = modValue.Insert(dotLocation + 1, ".");
                        J.Add(new ElementoLr1(elemLr1.key, modValue, elemLr1.token));
                    }
                }
            }
            return Cerradura(J);
        }

        private List<ElementoLr1> Cerradura(List<ElementoLr1> elementosCerradura)
        {
            for (int i = 0; i < elementosCerradura.Count; i++)
            {
                int dotLocation = elementosCerradura[i].GetDotLocation();
                if (dotLocation != -1)
                {
                    string B = elementosCerradura[i].value[dotLocation + 1].ToString();
                    string β = "";
                    for (int j = dotLocation + 2; j < elementosCerradura[i].value.Length; j++)
                        β += elementosCerradura[i].value[j];
                    char a = elementosCerradura[i].token;
                    List<string> Prims = Primero(β + a, ""); //?
                    List<List<string>> BProds = Aumentada.FindAll(query => query[0] == B);
                    foreach (List<string> Prod in BProds)
                    {
                        foreach (string PrimToken in Prims)
                        {
                            ElementoLr1 elemtonuevo;
                            if (Prod[1] != "Ɛ")
                                elemtonuevo = new ElementoLr1(Prod[0], "." + Prod[1], Char.Parse(PrimToken));
                            else
                                elemtonuevo = new ElementoLr1(Prod[0], ".", Char.Parse(PrimToken));

                            bool finded = elementosCerradura.Any(query => query.ToString() == elemtonuevo.ToString());
                            if (!finded)
                                elementosCerradura.Add(elemtonuevo);
                        }
                    }
                }
            }
            return elementosCerradura;
        }

        private void GeneraAumentada()
        {

            string s = DiccioAnalizador.Keys.ToList()[0];
            Aumentada.Add(new List<string> { s + "'", s });

            foreach (string Key in DiccioAnalizador.Keys)
            {
                foreach (string str in DiccioAnalizador[Key])
                {
                    List<string> input = new List<string> { Key, str };
                    Aumentada.Add(input);
                }
            }
        }

        private List<string> GeneraSimbGram()
        {
            List<string> sg = new List<string>();
            List<char> Uppers = new List<char>();
            List<char> Lowers = new List<char>();
            foreach (string Key in DiccioAnalizador.Keys)
                foreach (string str in DiccioAnalizador[Key])
                {
                    Uppers.AddRange(str.ToList().FindAll(comp => Char.IsUpper(comp)));
                    Lowers.AddRange(str.ToList().FindAll(comp => !Char.IsUpper(comp)));
                }
            Uppers.Add(Char.Parse(DiccioAnalizador.Keys.ToList()[0]));
            Uppers = Uppers.Distinct().ToList();
            Uppers.Remove('Ɛ');
            Lowers = Lowers.Distinct().ToList();
            sg.AddRange(Uppers.Select(c => c.ToString()).ToList());
            sg.AddRange(Lowers.Select(c => c.ToString()).ToList());
            return sg;
        }

        private bool CheckDifferentState(List<ElementoLr1> State1, List<ElementoLr1> State2)
        {
            List<string> s1 = new List<string>();
            List<string> s2 = new List<string>();
            foreach (ElementoLr1 it1 in State1)
                s1.Add(it1.ToString());
            foreach (ElementoLr1 it2 in State2)
                s2.Add(it2.ToString());
            bool isDifferent = !(s1.All(s2.Contains) && (s1.Count == s2.Count));
            return isDifferent;
        }

        public bool GeneraTablaLR1()
        {
            bool Lr1Error = false;
            List<string> Ir_A = new List<string>();
            Ir_A = sg.FindAll(query => Char.IsUpper(Char.Parse(query)));
            sg.RemoveAll(query => Ir_A.Contains(query));
            sg.Add("$");
            sg.AddRange(Ir_A);
            //Inicializa accion
            for (int j = 0; j < C.Count(); j++)
            {
                Accion.Add(j, new Dictionary<string, string>());
                foreach (var sgItem in sg)
                    Accion[j].Add(sgItem, "error");
            }

            //Encuentra los dn, rn y aC
            for (int i = 0; i < C.Count(); i++)
            {   //Recorre todos los estados Io ... In
                for (int j = 0; j < C[i].Count(); j++)
                {   //Recorre cada elemento del estado Ii
                    int dotIdx = C[i][j].GetDotLocation();
                    if (dotIdx >= 0)    //(a)
                    {
                        char a = C[i][j].value[dotIdx + 1];
                        if (!Char.IsUpper(a))
                        {
                            int destino = TablaDeEstados[a.ToString()][i];
                            if (destino >= 0)
                                Accion[i][a.ToString()] = "d" + destino;
                        }
                    }

                    if (dotIdx == -1 && C[i][j].key.Count() == 1)   //(b)
                    {
                        string ValueSinPunto = C[i][j].value.Remove(C[i][j].value.Count() - 1);
                        if (ValueSinPunto == "")
                            ValueSinPunto = "Ɛ";
                        List<string> RedInput = new List<string>() { C[i][j].key };
                        int α = Aumentada.FindIndex(query => query[0] == C[i][j].key && query[1] == ValueSinPunto);
                        if (Accion[i][C[i][j].token.ToString()] == "error")
                        {
                            Accion[i][C[i][j].token.ToString()] = "r" + α;
                        }
                        else
                        {
                            Lr1Error = true;
                            Accion[i][C[i][j].token.ToString()] = "d/r";
                        }
                    }

                    if (dotIdx == -1 && C[i][j].key.Count() > 1)    //(c)
                    {
                        if (C[i][j].key.Count() == 2 && C[i][j].value.Count() == 2 && C[i][j].token == '$')
                        {
                            if (Accion[i]["$"] == "error")
                            {
                                Accion[i]["$"] = "aC";
                            }
                            else
                            {
                                Lr1Error = true;
                                Accion[i][C[i][j].token.ToString()] = "d/a";
                            }
                        }
                        else
                            Lr1Error = true;
                    }
                }
            }

            //Inicializar Ir_a 
            foreach (string nt in Ir_A)
                foreach (KeyValuePair<int, int> KPItem in TablaDeEstados[nt])
                    if (KPItem.Value >= 0)
                        Accion[KPItem.Key][nt] = KPItem.Value.ToString();
            return Lr1Error;
        }

        public void UpdateAaslr(Dictionary<int, Dictionary<string, string>> Accion, string StrAnalisis)
        {
            Stack<int> EdosStack = new Stack<int>();

            EdosStack.Push(0);
            char[] strDiv = StrAnalisis.ToCharArray();
            bool AaslrLoop = true;
            int a = 0; //primer simbolo de strDiv
            while (AaslrLoop)
            {
                int s = EdosStack.Peek();
                if (!Accion[s].Keys.Contains(strDiv[a].ToString()))
                {
                    //Error 
                    DiccioLR1.Add("Entrada: ", new List<string>());
                    DiccioLR1["Entrada: "].Add("Incorrecta");
                    AaslrLoop = false;
                }
                else
                {
                    if (Accion[s][strDiv[a].ToString()][0] == 'd')
                    {
                        //Caso Desplazar
                        string modStr = Accion[s][strDiv[a].ToString()].Remove(0, 1);
                        int t = int.Parse(modStr);
                        EdosStack.Push(t);
                        a++;
                    }
                    else
                    {
                        if (Accion[s][strDiv[a].ToString()][0] == 'r')
                        {
                            //Caso Reducir
                            string modStr = Accion[s][strDiv[a].ToString()].Remove(0, 1);
                            int t = int.Parse(modStr);
                            int LoopCounter = 0;
                            string beta = "";
                            string A = "";
                            bool finded = false;
                            //Encuentra a A y beta
                            foreach (string Key in DiccioAnalizador.Keys)
                            {
                                foreach (string str in DiccioAnalizador[Key])
                                {
                                    LoopCounter++;
                                    if (t == LoopCounter && !finded)
                                    {
                                        A = Key;
                                        beta = str;
                                        finded = true;
                                    }
                                }
                            }
                            //Saca Beta tamaño de la pila
                            int β = beta.Length;
                            if (beta == "Ɛ")
                                β = 0;
                            for (int i = 0; i < β; i++)
                                EdosStack.Pop();
                            t = EdosStack.Peek();
                            int Ir_aValue = int.Parse(Accion[t][A].ToString());
                            EdosStack.Push(Ir_aValue);

                        }
                        else
                        {
                            if (Accion[s][strDiv[a].ToString()][0] == 'a')
                            {
                                //Aceptacion
                                DiccioLR1.Add("Entrada: ", new List<string>());
                                DiccioLR1["Entrada: "].Add("Correcta");
                                AaslrLoop = false;
                            }
                            else
                            {
                                //Error 
                                DiccioLR1.Add("Entrada: ", new List<string>());
                                DiccioLR1["Entrada: "].Add("Incorrecta");
                                AaslrLoop = false;
                            }
                        }
                    }
                }
            }
        }

        public void TransformToLALR()
        {
            List<List<int>> testResul = new List<List<int>>();
            List<List<ElementoLr1>> AuxC = new List<List<ElementoLr1>>(C);

            for (int i = 0; i < AuxC.Count; i++)
            {
                for (int j = 0; j < AuxC.Count; j++)
                {
                    if (i != j)
                    {
                        if (LALRCompare(AuxC[i], AuxC[j])) //UPDATE VALUES TABLA & C
                        {
                            int idX = C.FindIndex(pred => pred == AuxC[i]);
                            int idY = C.FindIndex(pred => pred == AuxC[j]);
                            testResul.Add(new List<int>() { idX, idY });
                            //Se agrega estado nuevo
                            AuxC.Add(LALRCombine(AuxC[i], AuxC[j]));
                            //Se elimina de C
                            List<ElementoLr1> elim1 = AuxC[i];
                            List<ElementoLr1> elim2 = AuxC[j];
                            AuxC.Remove(elim1);
                            AuxC.Remove(elim2);
                            j = AuxC.Count;
                            i = 0;
                        }
                    }
                }
            }
            for (int it = C.Count - 1; it >= 0; it--)
            {
                if (!testResul.Any(query => query.Any(pred => pred == it)))
                {
                    testResul.Insert(0, new List<int>() { it });
                }
            }

            foreach (string it1 in TablaDeEstados.Keys)
            {
                for (int i = 0; i < TablaDeEstados[it1].Count; i++)
                {
                    if (TablaDeEstados[it1][i] != -1)
                    {
                        int idx = testResul.FindIndex(query => query.Any(pred => pred == TablaDeEstados[it1][i]));
                        TablaDeEstados[it1][i] = idx;
                    }
                }
            }

            foreach (var item in testResul)
            {
                if (item.Count > 1)
                {
                    foreach (string it1 in TablaDeEstados.Keys)
                    {
                        TablaDeEstados[it1].Remove(item[1]);
                    }
                }
            }


            C = AuxC;
        }

        private bool LALRCompare(List<ElementoLr1> lr1, List<ElementoLr1> lr2)
        {
            foreach (ElementoLr1 it1 in lr1)
                if (!lr2.Any(pred => pred.value == it1.value && pred.key == it1.key))
                    return false;
            foreach (ElementoLr1 it2 in lr2)
                if (!lr1.Any(pred => pred.value == it2.value && pred.key == it2.key))
                    return false;
            return true;
        }

        private List<ElementoLr1> LALRCombine(List<ElementoLr1> lr1, List<ElementoLr1> lr2)
        {
            List<ElementoLr1> newState = new List<ElementoLr1>();
            newState.AddRange(lr1);
            foreach (ElementoLr1 it in lr2)
                if (!newState.Any(pred => pred.key == it.key && pred.value == it.value && pred.token == it.token))
                    newState.Add(it);
            return newState;
        }

    }
}
