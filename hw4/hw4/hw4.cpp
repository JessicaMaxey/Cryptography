// hw4.cpp : main project file.

#include "stdafx.h"

using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;
using namespace Encryption;

unsigned char ToChar(wchar_t in)
{
	return in & 0xFF;
}

int main(array<System::String ^> ^args)
{
	Keys ^ keys;
	unsigned long long p = 10007;
	unsigned long long q = 10009;

	BinaryWriter ^ out = gcnew BinaryWriter(Console::OpenStandardOutput());

	//Console::WriteLine("Please enter a number for prime P: ");
	//Console::WriteLine("Please enter a number for prime Q: ");


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

    return 0;
}
