# Zadania do modelowania

## Linki pomocnicze do regexa

* https://regex101.com/
* https://regexper.com/#%5C%28%28%5Cd%5Cd%29%20min.*%5C%29

## Zadanie 1

### Polecenie

Zapisz do pliku, ile czasu zajęło budowanie Fryderyka Komciura.
PAMIĘTAJ O TESTACH AUTOMATYCZNYCH.

### Dane

| Klucz                              | Wartość                   |
|------------------------------------|---------------------------|
| Profil                             | Fryderyk Komciur          |
| Ścieżka                            | \cybermagic\karty-postaci\1807-fryderyk-komciur.md |
| Regex dla czasu:                   | \((\d\d) min.*\)          |
| Regex dla imienia:                 | title: "(\w+ \w+)"        |

### Oczekiwany efekt

"Fryderyk Komciur był budowany 23 minuty"

## Zadanie 2

### Polecenie

Zapisz do pliku, ile czasu zajęło budowanie WSZYSTKICH postaci z folderu
PAMIĘTAJ O TESTACH AUTOMATYCZNYCH.

### Dane

| Klucz                              | Wartość                   |
|------------------------------------|---------------------------|
| Ścieżka                            | \cybermagic\karty-postaci |
| Regex dla czasu (już był)          | \((\d\d) min.*\)          |

### Oczekiwany efekt

"Wszystkie postacie do tej pory budowane były XX godzin XX minut"

## Zadanie 2

### Polecenie

Zapisz do pliku (poniżej poprzedniego rekordu), ile czasu zajęło budowanie WSZYSTKICH postaci z folderu

### Dane

| Klucz                              | Wartość                   |
|------------------------------------|---------------------------|
| Ścieżka                            | \cybermagic\karty-postaci |
| Regex dla czasu (już był)          | \((\d\d) min.*\)          |

### Oczekiwany efekt

"Wszystkie postacie do tej pory budowane były XX godzin XX minut"

## Zadanie 3

### Polecenie

Zapisz do pliku (poniżej poprzedniego rekordu):

* które postacie NIE mają podanej ilości czasu budowania - zapisz ich identyfikatory (imię i nazwisko)
* wylicz średni czas budowania postaci z tych które miały podany czas budowania
* ZIGNORUJ PLIK TEMPLATE (1807-_template.md) - on świadomie jest pusty
* załóż, że te postacie (bez podanego czasu) były budowane tak samo szybko jak średni czas
* napisz ile najpewniej zajął czas budowania postaci

PAMIĘTAJ O TESTACH AUTOMATYCZNYCH.

### Dane

| Klucz                              | Wartość                   |
|------------------------------------|---------------------------|
| Ścieżka                            | \cybermagic\karty-postaci |
| Regex dla imienia (już był)        | title: "(\w+ \w+)"        |
| Regex dla czasu (już był)          | \((\d\d) min.*\)          |

### Oczekiwany efekt

// whitespace są tu nieistotne, byle było czytelne

"
Postacie, które nie mają podanego czasu to:

* Artur Perikas
* Majka Perikas
* Olga Myszeczka

Średni czas budowania postaci to: XX minut.
Uwzględniając powyższe, postacie do tej pory budowane były najpewniej XX godzin XX minut.
"

## Zadanie 4

### Polecenie

Zapisz do pliku (poniżej poprzedniego rekordu) w których opowieściach występowała Magda Patiril? (przykładowo popatrzcie na "Mściwą Rybę z Eteru")
PAMIĘTAJ O TESTACH AUTOMATYCZNYCH.

### Dane

| Klucz                                 | Wartość                   |
|---------------------------------------|---------------------------|
| Ścieżka                               | \cybermagic\opowiesci     |
| Regex dla znalezienia tam Magdy       | # Zas.ugi.*?Magda Patiril.*?# |
| Regex dla znalezienia nazwy Opowieści | title: +"([\w\s]+)"       |

### Oczekiwany efekt

// whitespace są tu nieistotne, byle było czytelne

"
Magda Patiril występowała w następujących Opowieściach:

* Niewidzialne potwory z rzeki
* Mściwa ryba z Eteru

"

## Zadanie 5

### Polecenie

Chcę mieć możliwość konfigurowania KTÓRE polecenia będą się odpalały a które nie. Chcę też móc wyspecyfikować nazwę pliku (np. przez config file).

### Dane

* dostaniesz nazwę pliku, np:
    * "kalarepa.md"
    * "artur-perikas.xxx"
* dostaniesz które zadania mają odpalić, np:
    * 1, 3, 4
    * 1, 2,3, 4,5, 9
    * delimiterem jest cokolwiek co NIE jest cyfrą

| Klucz                                 | Wartość                   |
|---------------------------------------|---------------------------|
| Regex ekstraktujący liczby            | \d+                       |

### Oczekiwany efekt

* wszystkie polecenia które były prawidłowe (np. 1, 2, 3, 4, 5) się wykonają i odpowiednie rzeczy trafią do pliku
* wszystkie polecenia które jeszcze się nie pojawiły (np. 6, 888) się NIE wykonają, ale program zadziała
* wszystkie śmieci będą zignorowane
* wszystko będzie zapisywało się do pliku o wymaganej nazwie w wymaganej ścieżce (jak jest to niemożliwa lokalizacja, rzuć wyjątek ArgumentException)

Przykład:
1 2, 3kot4 -> odpal polecenia 1, 2, 3, 4

## Zadanie 6

### Polecenie

Zapisz do pliku (poniżej poprzedniego rekordu) z jakimi postaciami i ile razy występowała Kalina Rotmistrz.
PAMIĘTAJ O TESTACH AUTOMATYCZNYCH.

### Dane

| Klucz                                 | Wartość                   |
|---------------------------------------|---------------------------|
| Ścieżka                               | \cybermagic\opowiesci     |
| Regex wyciągający Zasługi             | # Zas.ugi\s+(.+?)#        |
| Regex dla znalezienia wszystkich postaci z sekcji Zasługi: | ^\* (\w+ \w+): |

### Oczekiwany efekt

// LICZBY PONIŻEJ MOGĄ KŁAMAĆ

"
Kalina Rotmistrz spotkała następujące postacie:

* Stach Sosnowiecki: 2 razy
* Magda Patiril: 2 razy
* Kacper Wontarczyk: 1 raz
* ...

"

## Zadanie 7

### Polecenie

Zapisz do pliku (poniżej poprzedniego rekordu) dokument grupujący postacie:

* Które zarówno występują w jakiejś Opowieści jak i mają Profil
* Które mają jedynie Profil
* Które występują jedynie w Opowieści

W powyższym uwzględnij unikalne identyfikatory (nazwy plików)

PAMIĘTAJ O TESTACH AUTOMATYCZNYCH.

### Dane

| Klucz                                 | Wartość                   |
|---------------------------------------|---------------------------|
| Ścieżka 1                             | \cybermagic\opowiesci     |
| Ścieżka 2                             | \cybermagic\karty-postaci |

### Oczekiwany efekt

"
**Postacie mające Profil i Opowieść**:

* Kalina Rotmistrz
* Stach Sosnowiecki
* ...

**Postacie mające tylko Profil**:

* Fryderyk Komciur, 1807-fryderyk-komciur.md
* Wiktor Satarail, 1807-wiktor-satarail.md
* ...

**Postacie występujące tylko w Opowieściach**:

* Kacper Wontarczyk, 180701-dwa-rejsy-w-potrzebie.md
* Magda Patiril, 180708-niewidzialne-potwory-z-rzeki.md, 180718-msciwa-ryba-z-eteru.md
* ...

"