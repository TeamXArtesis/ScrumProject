package com.teamx.domain;

import java.util.Collection;

public class Klas {
	private int id;
	private String afkorting;
	private String naam;
	private Collection<Olod> olods;

	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getAfkorting() {
		return afkorting;
	}
	public void setAfkorting(String afkorting) {
		this.afkorting = afkorting;
	}
	public String getNaam() {
		return naam;
	}
	public void setNaam(String naam) {
		this.naam = naam;
	}
	public Collection<Olod> getOlods() {
		return olods;
	}
	public void setOlods(Collection<Olod> olods) {
		this.olods = olods;
	}
}
