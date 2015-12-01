// hw4.cpp : main project file.

#include "stdafx.h"
#include <iostream>
using std::cout;
using std::endl;
#include <string>
using std::string;

using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;
using namespace System::Text;
using namespace Encryption;

array<Keys ^> ^ ProduceKeys()
{
	int count = 0;
	Keys ^ rsa_keys;
	array<Keys ^> ^ ret = gcnew array<Keys ^>(3);

	for (int i = 0; i < 3; i++)
	{
		rsa_keys = Encryption::diffie_hellman::KeyGen(Encryption::diffie_hellman::GeneratePrime(10000, 50000), Encryption::diffie_hellman::GeneratePrime(10000, 50000));
		
		cout << "Key e " << rsa_keys->public_key_e << " ";
		cout << "Key n " << rsa_keys->public_key_n << " ";
		cout << "Key d " << rsa_keys->private_key  << endl;

		ret[i] = rsa_keys;
	}

	cout << endl;

	return ret;
}

unsigned char ToUChar(wchar_t in)
{
	return in & 0xFF;
}

wchar_t ToChar(unsigned char in)
{
	return in & 0xFF;
}


int main(array<System::String ^> ^args)
{
	bool again = true;
	array<Keys^> ^ stored_keys;
	unsigned long long p = 0;
	unsigned long long q = 0;
	unsigned long long e = 0;


	while (again == true)
	{
		Console::WriteLine("Please select which program to run: ");
		Console::WriteLine("1.) Generate three sets of keys ");
		Console::WriteLine("2.) Encryption/Decryption ");
		Console::WriteLine("3.) Exit");


		auto sel = Convert::ToUInt16(Char::GetNumericValue(Console::ReadKey().KeyChar));

		
		cout << endl;

		if (sel == 1)
		{
			stored_keys = ProduceKeys();
		}
		else if (sel == 2)
		{
			bool try_again = true;

			Keys ^ keys;

			while (try_again == true)
			{

				Console::WriteLine("Please select a key to use:");
				Console::WriteLine("Key 1: " + "Key e " + stored_keys[0]->public_key_e + " Key n " + stored_keys[0]->public_key_n + " Key d " + stored_keys[0]->private_key);
				Console::WriteLine("Key 2: " + "Key e " + stored_keys[1]->public_key_e + " Key n " + stored_keys[1]->public_key_n + " Key d " + stored_keys[1]->private_key);
				Console::WriteLine("Key 3: " + "Key e " + stored_keys[2]->public_key_e + " Key n " + stored_keys[2]->public_key_n + " Key d " + stored_keys[2]->private_key);

				auto key_choice = Convert::ToUInt16(Char::GetNumericValue(Console::ReadKey().KeyChar));

				cout << endl;

				if (key_choice > 0 && key_choice <= 3)
				{
					keys = stored_keys[key_choice - 1];
					try_again = false;
				}
			}

			try_again = true;

			while (try_again == true)
			{
				Console::WriteLine("Please select \"e\" for encryption, or \"d\" for decryption: ");
				auto cryption_type = Char::ToLower(Console::ReadKey().KeyChar);

				cout << endl;

				if (cryption_type == 'e')
				{
					BinaryWriter ^ out = gcnew BinaryWriter(Console::OpenStandardOutput());

					Console::WriteLine("Please enter a message: ");
					auto msg_in = Console::ReadLine();

					auto converter = gcnew Converter<wchar_t, unsigned char>(ToUChar);
					auto converted_message = array<wchar_t>::ConvertAll<wchar_t, unsigned char>(msg_in->ToCharArray(), converter);

					auto enc_msg_out = rsa::Encrypt(keys, converted_message)->ToArray();

					Console::WriteLine("\r\nEncrypted message: ");

					for (int i = 0; i < enc_msg_out->Length; i++)
						Console::Write(enc_msg_out[i] + " ");

					try_again = false;
				}
				else if (cryption_type == 'd')
				{
					BinaryWriter ^ out = gcnew BinaryWriter(Console::OpenStandardOutput());

					Console::WriteLine("Please enter a message: ");
					
					auto msg_in = Console::ReadLine()->Split(' ');

					List<unsigned long long> ^ input = gcnew List<unsigned long long>();

					for (int i = 0; i < msg_in->Length; i++)
					{
						input->Add(UInt64::Parse(msg_in[i]));
					}
					
					auto converter = gcnew Converter<unsigned char, wchar_t >(ToChar);
					auto dec_mesg_out = array<wchar_t>::ConvertAll<unsigned char, wchar_t>(rsa::Decrypt(keys, input->ToArray()), converter);

					Console::WriteLine("\r\nDecrypted message: ");
					Console::WriteLine(dec_mesg_out);

					try_again = false;
				}

			}
		}
		else if (sel == 3)
		{
			again = false;
		}
	}

	return 0;
}

