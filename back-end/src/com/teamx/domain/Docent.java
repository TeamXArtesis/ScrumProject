package com.teamx.domain;

import java.util.Collection;

public class Docent {
	private int id;
	private String naam;
	private String voornaam;
	private String email;
	private Collection<Olod> olods;
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getNaam() {
		return naam;
	}
	public void setNaam(String naam) {
		this.naam = naam;
	}
	public String getVoornaam() {
		return voornaam;
	}
	public void setVoornaam(String voornaam) {
		this.voornaam = voornaam;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public Collection<Olod> getOlods() {
		return olods;
	}
	public void setOlods(Collection<Olod> olods) {
		this.olods = olods;
	}
	
}
