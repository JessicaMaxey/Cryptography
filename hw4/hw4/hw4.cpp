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

unsigned char ToChar(wchar_t in)
{
	return in & 0xFF;
}


int main(array<System::String ^> ^args)
{
	bool again = true;
	array<Keys^> ^ stored_keys;

	while (again == true)
	{
		Console::WriteLine("Please select which program to run: ");
		Console::WriteLine("1.) Generate three sets of keys ");
		Console::WriteLine("2.) Encryption/Decryption ");
		Console::WriteLine("3.) Exit");


		auto program_select = Console::ReadLine();
		
		cout << endl;

		if (program_select == "1")
		{
			stored_keys = ProduceKeys();
		}
		else if (program_select == "2")
		{
			Keys ^ keys;

			Console::WriteLine("Please enter keys:");
			Console::WriteLine("Key p:");
			unsigned long long p = UInt64::Parse(Console::ReadLine());
			Console::WriteLine("Key q:");
			unsigned long long q = UInt64::Parse(Console::ReadLine());
			Console::WriteLine("Key e:");
			unsigned long long e = UInt64::Parse(Console::ReadLine());

			BinaryWriter ^ out = gcnew BinaryWriter(Console::OpenStandardOutput());

			keys = diffie_hellman::KeyGen(p, q);

			Console::WriteLine("Please enter a message: ");
			auto msg_in = Console::ReadLine();

			auto converter = gcnew Converter<wchar_t, unsigned char>(ToChar);
			auto enc_msg_out = rsa::Encrypt(keys, Array::ConvertAll<wchar_t, unsigned char>(msg_in->ToCharArray(), converter))->ToArray();
			auto dec_mesg_out = rsa::Decrypt(keys, enc_msg_out);

			Console::WriteLine("\r\nEncrypted message: ");
			for (int i = 0; i < enc_msg_out->LongLength; i++)
				out->Write(enc_msg_out[i]);

			Console::WriteLine("\r\nDecrypted message: ");
			out->Write(dec_mesg_out);

			Console::ReadKey();

		}
		else if (program_select == "3")
		{
			again = false;
		}
		else
		{
			Console::WriteLine("Please select which program to run: ");
			Console::WriteLine("1.) Generate three sets of keys ");
			Console::WriteLine("2.) Encryption/Decryption ");
			Console::WriteLine("3.) Exit");

			auto program_select = Console::ReadLine();

		}
	}

	return 0;
}

