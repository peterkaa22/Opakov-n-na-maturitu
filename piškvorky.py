pole = [" ", " ", " ", " ", " ", " ", " ", " ", " "]

def vypis():
    print(pole[0] + "|" + pole[1] + "|" + pole[2])
    print("-+-+-")
    print(pole[3] + "|" + pole[4] + "|" + pole[5])
    print("-+-+-")
    print(pole[6] + "|" + pole[7] + "|" + pole[8])

def vyhra(znak):
    if pole[0] == znak and pole[1] == znak and pole[2] == znak:
        return True
    if pole[3] == znak and pole[4] == znak and pole[5] == znak:
        return True
    if pole[6] == znak and pole[7] == znak and pole[8] == znak:
        return True
    if pole[0] == znak and pole[3] == znak and pole[6] == znak:
        return True
    if pole[1] == znak and pole[4] == znak and pole[7] == znak:
        return True
    if pole[2] == znak and pole[5] == znak and pole[8] == znak:
        return True
    if pole[0] == znak and pole[4] == znak and pole[8] == znak:
        return True
    if pole[2] == znak and pole[4] == znak and pole[6] == znak:
        return True
    return False

hrac = "X"
tahy = 0

while tahy < 9:
    vypis()
    pozice = int(input("Zadej cislo pole 1-9: ")) - 1
    
    if pole[pozice] == " ":
        pole[pozice] = hrac
        tahy = tahy + 1
        
        if vyhra(hrac):
            vypis()
            print("Vyhral hrac " + hrac)
            break
        
        if hrac == "X":
            hrac = "O"
        else:
            hrac = "X"
    else:
        print("Toto pole je uz obsazene")

if tahy == 9 and not vyhra("X") and not vyhra("O"):
    vypis()
    print("Remiza")