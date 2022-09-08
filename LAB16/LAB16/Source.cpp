#include <iostream>
#include <string>
#include <vector>
#include <sstream>
#include <iterator>

using namespace std;

int main() {

	setlocale(LC_ALL, "Rus");

	string str = "Hello world! ss ss rr",word;
	char sym = 'l', ch;

	istringstream in(str);
	ostringstream out;

	vector<string> _str;
	vector<char> letter;

	while (in >> word) {
		istringstream in_ch(word);
		while (in_ch >> ch) {
			if (sym == ch) {
				letter.push_back(ch);
				letter.push_back(' ');
			}
			else {
				letter.push_back(ch);
			}
		}
		string wrd(letter.begin(), letter.end());
		_str.push_back(wrd);
		letter.clear();
	}
	copy(_str.begin(), _str.end(), ostream_iterator<string>(out, " "));
	string mod_str = out.str();

	istringstream mod_in(mod_str);
	out.clear();

	vector<string> non_repeat;
	while (mod_in >> word) {
		if (find(non_repeat.begin(), non_repeat.end(), word) == non_repeat.end()) {
			non_repeat.push_back(word);
		}
	}

	copy(_str.begin(), _str.end(), ostream_iterator<string>(out, " "));
	cout << "Измененная строка:" << mod_str << endl;
	cout << "Кол-во неповторяющихся слов: " << non_repeat.size()<< endl;
	system("pause");
}