// This is the main DLL file.

#include "stdafx.h"
#include <math.h>
#include <algorithm>
#include "rsa.h"

using namespace System::Collections::Generic;
using namespace Encryption;

ull GeneratePrime(ull min, ull max)
{
	while (1)
	{
		ull randVal = ((ull)rand()) << 32 | rand();
		ull ret = (randVal % ((max - 1) - (min + 1))) + min;
		ull i = 2;

		if (ret % 2 == 0)
			ret++;

		for (; i < ret / 2; i++)
		{
			if (ret % i == 0)
				break;
		}

		if (i == ret / 2)
			return ret;
	}
	return 0;
}

long long ModInverse(long long a, long long b)
{
	long long b0 = b, t, q;
	long long x0 = 0, x1 = 1;

	if (b == 1) return 1;

	while (a > 1) {
		q = a / b;
		t = b, b = a % b, a = t;
		t = x0, x0 = x1 - q * x0, x1 = t;
	}

	if (x1 < 0) x1 += b0;

	return x1;
}

Keys ^ Encryption::diffie_hellman::KeyGen(ull p, ull q)
{
	ull m = 0;
	ull c = 0;
	ull t = 0;
	
	Keys ^ ret = gcnew Keys();

	//product of (p-1 * q-1)
	t = (p - 1) * (q - 1);
	//3120

	ret->public_key_e = GeneratePrime(1, t);
	ret->public_key_n = p * q;

	//compute the private key, which is the mod inverse of e mod n
	ret->private_key = ModInverse(ret->public_key_e, t);
	
	return ret;
}

List<ull> ^ Encryption::rsa::Encrypt(Keys ^ key, array<unsigned char> ^ message)
{
	unsigned char pad[sizeof(chunk_type)] = { 0 };
	List<ull>^ cipher_text = gcnew List<ull>();

	pin_ptr<unsigned char> pinned_msg = &message[0];

	ull temp = 0;

	chunk_type * msg_to_convert = (chunk_type *)pinned_msg;
	chunk_type * pad_ptr = (chunk_type *)pad;

	chunk_type length = message->LongLength / sizeof(chunk_type);
	chunk_type remainder = message->LongLength % sizeof(chunk_type);
	chunk_type pad_val = 0;

	for (unsigned long long i = 0; i < length; i++)
	{
		temp = 1;

		for (int p = 0; p < key->public_key_e; p++)
			temp = (temp * msg_to_convert[i]) % key->public_key_n;

		cipher_text->Add(temp);
	}

	if (remainder)
	{
		memcpy(pad, msg_to_convert + length, remainder);
		pad_val = *pad_ptr;

		temp = 1;
		for (int p = 0; p < key->public_key_e; p++)
			temp = (temp * pad_val) % key->public_key_n;

		cipher_text->Add(temp);
	}

	return cipher_text;
}

array<unsigned char> ^ Encryption::rsa::Decrypt(Keys ^ key, array<ull> ^ cipher_text)
{
	unsigned char pad[sizeof(chunk_type)] = { 0 };
	array<unsigned char>^ message = gcnew array<unsigned char>(cipher_text->LongLength);

	pin_ptr<unsigned char> pinned_msg = &message[0];

	ull temp;

	chunk_type * msg_to_return = (chunk_type *)pinned_msg;
	chunk_type * pad_ptr = (chunk_type *)pad;

	chunk_type length = message->LongLength / sizeof(chunk_type);
	chunk_type remainder = message->LongLength % sizeof(chunk_type);
	chunk_type pad_val = 0;

	for (unsigned long long i = 0; i < length; i++)
	{
		temp = 1;

		for (int p = 0; p < key->private_key; p++)
			temp = (temp * cipher_text[i]) % key->public_key_n;

		msg_to_return[i] = temp;
	}

	if (remainder)
	{
		temp = 1;

		for (int p = 0; p < key->private_key; p++)
			temp = (temp * cipher_text[length]) % key->public_key_n;

		*pad_ptr = temp;

		memcpy(&msg_to_return + length, pad_ptr, remainder);
	}

	return message;
}
